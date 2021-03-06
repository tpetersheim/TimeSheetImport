﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using StringExtensions;
using System.Threading;
using System.Diagnostics;

namespace TimeSheetImport
{
    internal partial class Main : Form
    {
        internal TimeSheetBackup TimeSheetBackup;
        internal TimeSheetExcel TimeSheetExcel;
        private ImportProgress importProgress;
        public CancellationTokenSource tokenSource;

        internal Main()
        {
            InitializeComponent();

            loadLastSettings();
        }

        private void loadLastSettings()
        {
            txtBackupFile.Text = getLatestBackupDataFile(Properties.Settings.Default.BackupDataFilePath);
            txtTimeSheetExcelFile.Text = Properties.Settings.Default.TimeSheetExcelFilePath;
            txtOutputTimeSheet.Text = !string.IsNullOrEmpty(Properties.Settings.Default.OutputTimeSheetFolderPath) ? Path.Combine(Properties.Settings.Default.OutputTimeSheetFolderPath, "{0}.xls".With(DateTime.Now.ToString("yyyy-MM-dd"))) : Properties.Settings.Default.OutputTimeSheetFolderPath;
            dtStartDate.Value = DateTime.Now.Date.AddDays(-7);
            dtEndDate.Value = DateTime.Now.Date;
        }

        private void saveLastSettings()
        {
            Properties.Settings.Default.BackupDataFilePath = txtBackupFile.Text;
            Properties.Settings.Default.TimeSheetExcelFilePath = txtTimeSheetExcelFile.Text;
            try
            {
                var outputFile = new FileInfo(txtOutputTimeSheet.Text);
                Properties.Settings.Default.OutputTimeSheetFolderPath = !string.IsNullOrEmpty(outputFile.Extension) ? Directory.GetParent(txtOutputTimeSheet.Text).ToString() : txtOutputTimeSheet.Text;
            } catch{}
            Properties.Settings.Default.StartDate = dtStartDate.Value;
            Properties.Settings.Default.EndDate = dtEndDate.Value;
            Properties.Settings.Default.Save();
        }

        private string getLatestBackupDataFile(string lastFilePath)
        {
            string latestFileBackup = "";

            try
            {
                if (!string.IsNullOrWhiteSpace(lastFilePath))
                {
                    DirectoryInfo directory = null;
                    if (File.Exists(lastFilePath))
                        directory = new DirectoryInfo(Directory.GetParent(lastFilePath).ToString());
                    else if (Directory.Exists(lastFilePath))
                        directory = new DirectoryInfo(lastFilePath);

                    if (directory != null)
                        latestFileBackup = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault().FullName;
                }
            }
            catch 
            {
                latestFileBackup = lastFilePath;
            }

            return latestFileBackup;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLastSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectBackupDataFile_Click(object sender, EventArgs e)
        {
            setDirectoryAndFile(openFileDialog, txtBackupFile.Text);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupFile.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectTimeSheetExcelFile_Click(object sender, EventArgs e)
        {
            setDirectoryAndFile(openFileDialog, txtTimeSheetExcelFile.Text);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTimeSheetExcelFile.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectOutputTimeSheet_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel Files(*.xls;)|*.xls|All files (*.*)|*.*";
            setDirectoryAndFile(saveFileDialog, txtOutputTimeSheet.Text);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputTimeSheet.Text = saveFileDialog.FileName;
            }
        }

        private void setDirectoryAndFile(FileDialog fileDialog, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                var fileName = Path.GetFileName(filePath);
                fileDialog.InitialDirectory = !string.IsNullOrEmpty(fileName) ? Path.GetDirectoryName(filePath) : filePath;
                fileDialog.FileName = !string.IsNullOrEmpty(Path.GetExtension(filePath)) ? Path.GetFileName(filePath) : "";
            }
            else
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileDialog.FileName = "";
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            performImport();
        }

        private async Task performImport()
        {
            try
            {
                if (validateInputs())
                {
                    startImport();

                    tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    var progress = new Progress<ImportProgressReport>(r =>
                    {
                        importProgress.lblTotalEntries.Text = r.TotalEntries.ToString();
                        importProgress.lblCurrentImportIndex.Text = (r.CurrentEntryIndex + 1).ToString();
                        importProgress.progressBarImport.Maximum = r.TotalEntries;
                        importProgress.progressBarImport.Value = r.CurrentEntryIndex + 1;

                        importProgress.lblStatus.Text = r.CurrentEntryDescription;
                    });

                    parseFiles();
                    await Task.Run(() => writeEntriesToTimeSheet(progress, token), token);
                    endImport();

                    TimeSheetExcel.Save();
                    TimeSheetExcel.Close();
                    //Process.Start(txtOutputTimeSheet.Text);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError(ex, "Problem Creating Time Sheet");
            }
            finally
            {
                if (TimeSheetExcel != null && TimeSheetExcel.AnyFileOpen)
                {
                    TimeSheetExcel.Close();
                }
            }
        }

        private void startImport()
        {
            this.Enabled = false;
            //btnImport.Enabled = false;
            importProgress = new ImportProgress();
            importProgress.Show();
        }

        private void endImport()
        {
            importProgress.lblStatus.Text = "Import Complete!";
            importProgress.btnOkay.Enabled = true;
            importProgress.btnCancel.Enabled = false;
            this.Enabled = true;
        }

        private bool validateInputs()
        {
            var outputFile = new FileInfo(txtOutputTimeSheet.Text);
            if (outputFile.Extension != ".xls" && FileHelper.IsValidFileName(outputFile.FullName))
            {
                MessageHelper.ShowError("Please define a valid file.", "Invalid Save File");
                return false;
            }

            var outputFileParentPath = Directory.GetParent(outputFile.FullName).ToString();
            try
            {
                Directory.CreateDirectory(outputFileParentPath);
                File.Delete(txtOutputTimeSheet.Text);
                File.Copy(txtTimeSheetExcelFile.Text, txtOutputTimeSheet.Text);
            }
            catch (Exception exception)
            {
                if (exception is System.IO.IOException)
                {
                    MessageHelper.ShowError("There was an error trying to save your file.  "
                        + "Make sure the file open or being used by another process and try again.", "Cannot Save File");
                    return false;
                }
                else
                    MessageHelper.ShowError(exception, "Cannot create save file");
            }

            return true;
        }

        private void parseFiles()
        {
            TimeSheetExcel = new TimeSheetExcel(txtOutputTimeSheet.Text);
            TimeSheetBackup = new TimeSheetBackup(txtBackupFile.Text);
        }

        private void writeEntriesToTimeSheet(IProgress<ImportProgressReport> progress, CancellationToken token)
        {
            try
            {
                List<TimeSheetTask> tasks = TimeSheetBackup.GetTasksWithinTimeframe(dtStartDate.Value, dtEndDate.Value);

                int taskIndex = 0;
                int taskCount = tasks.Count;
                foreach (TimeSheetTask task in tasks)
                {
                    //Check for cancellation
                    if (token.IsCancellationRequested)
                    {
                        if (progress != null)
                            progress.Report(new ImportProgressReport()
                            {
                                CurrentEntryIndex = taskIndex,
                                TotalEntries = taskCount,
                                CurrentEntryDescription = "Import cancelled."
                            });

                        token.ThrowIfCancellationRequested();
                    }

                    var breaks = TimeSheetBackup.GetBreaks(task.TaskId);
                    var job = TimeSheetBackup.GetProject(task.TaskId);
                    var item = TimeSheetBackup.GetTags(task.TaskId).FirstOrDefault();
                    var jobName = (job != null ? job.NameTrimmed : "");
                    var itemName = (item != null ? item.NameTrimmed : "");

                    //Report progress
                    if (progress != null)
                    {
                        progress.Report(new ImportProgressReport()
                        {
                            CurrentEntryIndex = taskIndex,
                            TotalEntries = taskCount,
                            CurrentEntryDescription = "{0:MM/dd/yy} : {1} - {2}".With(task.StartDateParsed, jobName, itemName)
                        });
                    }

                    var hours = (task.EndDateParsed - task.StartDateParsed);
                    var breakHours = TimeSpan.Parse("0");
                    breaks.ForEach(b => breakHours += (b.EndDateParsed - b.StartDateParsed));
                    hours -= breakHours;
                    var tsEntry = new TimeSheetExcelEntry()
                    {
                        Date = task.StartDateParsed,
                        Job = jobName,
                        Item = itemName,
                        Notes = task.DescriptionTrimmed,
                        Hours = hours,
                    };
                    TimeSheetExcel.WriteEntry(tsEntry);

                    //Write task's breaks as separate entries
                    foreach (var brk in breaks)
                    {
                        var tsBreakEntry = new TimeSheetExcelEntry()
                        {
                            Date = task.StartDateParsed,
                            Job = jobName,
                            Item = itemName,
                            Notes = "BREAK: {0}".With(brk.Description),
                            Hours = (brk.EndDateParsed - brk.StartDateParsed)
                        };
                        TimeSheetExcel.WriteEntry(tsBreakEntry);
                    }

                    taskIndex++;
                }
            }
            catch (Exception excep)
            {
                if (excep is OperationCanceledException)
                    return;
                else
                    MessageHelper.ShowError(excep, "Problem Writing Entries");
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtEndDate.Value = dtStartDate.Value.AddDays(7);
        }
    }
}
