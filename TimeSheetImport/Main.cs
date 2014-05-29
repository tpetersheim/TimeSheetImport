using System;
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

namespace TimeSheetImport
{
    internal partial class Main : Form
    {
        internal TimeSheetBackup TimeSheetBackup;
        internal TimeSheetExcel TimeSheetExcel;

        internal Main()
        {
            InitializeComponent();

            loadLastSettings();
            //dtStartDate.Text = "2014/04/01";
        }

        private void loadLastSettings()
        {
            txtBackupFile.Text = Properties.Settings.Default.BackupDataFilePath;
            txtTimeSheetTemplate.Text = Properties.Settings.Default.TimeSheetTemplateFilePath;
            txtOutputTimeSheet.Text = !string.IsNullOrEmpty(Properties.Settings.Default.OutputTimeSheetFolderPath) ? Path.Combine(Properties.Settings.Default.OutputTimeSheetFolderPath, "{0}.xls".With(DateTime.Now.ToString("yyyy-MM-dd"))) : Properties.Settings.Default.OutputTimeSheetFolderPath;
            dtStartDate.Value = DateTime.Now.AddDays(-14);
            dtEndDate.Value = DateTime.Now;
        }

        private void saveLastSettings()
        {
            Properties.Settings.Default.BackupDataFilePath = txtBackupFile.Text;
            Properties.Settings.Default.TimeSheetTemplateFilePath = txtTimeSheetTemplate.Text;
            try
            {
                var outputFile = new FileInfo(txtOutputTimeSheet.Text);
                Properties.Settings.Default.OutputTimeSheetFolderPath = !string.IsNullOrEmpty(outputFile.Extension) ? Directory.GetParent(txtOutputTimeSheet.Text).ToString() : txtOutputTimeSheet.Text;
            } catch{}
            Properties.Settings.Default.StartDate = dtStartDate.Value;
            Properties.Settings.Default.EndDate = dtEndDate.Value;
            Properties.Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLastSettings();
            //if (TimeSheetExcel != null && TimeSheetExcel.AnyFileOpen)
            //{
            //    TimeSheetExcel.Close();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectBackupDataFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = !string.IsNullOrWhiteSpace(txtBackupFile.Text) ? txtBackupFile.Text : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupFile.Text = openFileDialog.FileName;
            }
        }

        private void btnSelectTimeSheetTemplate_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = !string.IsNullOrWhiteSpace(txtTimeSheetTemplate.Text) ? txtTimeSheetTemplate.Text : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTimeSheetTemplate.Text = openFileDialog.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                toggleImportState(true);
                if (validateInputs())
                {
                    parseFiles();
                    writeEntriesToTimeSheet();
                    MessageHelper.ShowMessage("Done writing entries!!!");
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
                toggleImportState(false);
            }
        }

        private void toggleImportState(bool turnOn)
        {
            if (turnOn)
            {
                this.Cursor = Cursors.WaitCursor;
                progressBarImport.Visible = true;
            }
            else
            {
                this.Cursor = Cursors.Default;
                progressBarImport.Visible = false;
            }
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
                File.Copy(txtTimeSheetTemplate.Text, txtOutputTimeSheet.Text);
            }
            catch (Exception exception)
            {
                MessageHelper.ShowError(exception, "Cannot create save file");
                return false;
            }

            return true;
        }

        private void parseFiles()
        {
            TimeSheetExcel = new TimeSheetExcel(txtOutputTimeSheet.Text);
            TimeSheetBackup = new TimeSheetBackup(txtBackupFile.Text);
        }

        private void writeEntriesToTimeSheet()
        {
            List<TimeSheetTask> tasks = TimeSheetBackup.GetTasksWithinTimeframe(dtStartDate.Value, dtEndDate.Value);

            progressBarImport.Maximum = tasks.Count;
            progressBarImport.Value = 0;
            foreach (TimeSheetTask task in tasks)
            {
                var breaks = TimeSheetBackup.GetBreaks(task.TaskId);
                TimeSpan breakTotal = TimeSpan.Parse("0");
                foreach (var brk in breaks)
                {
                    breakTotal += (brk.EndDateParsed - brk.StartDateParsed);
                }

                var job = TimeSheetBackup.GetProject(task.TaskId);
                var item = TimeSheetBackup.GetTags(task.TaskId).FirstOrDefault();
                TimeSpan hours = (task.EndDateParsed - task.StartDateParsed) - breakTotal;
                var notes = task.DescriptionTrimmed + (breakTotal.Hours > 0 ? "Break: {0} min".With(breakTotal.Minutes) : "");

                var tsEntry = new TimeSheetExcelEntry()
                {
                    Date = task.StartDateParsed,
                    Job = (job != null ? job.NameTrimmed : ""),
                    Item = (item != null ? item.NameTrimmed : ""),
                    Notes = notes,
                    Hours = hours,
                };
                TimeSheetExcel.WriteEntry(tsEntry);

                progressBarImport.Increment(1);
                Application.DoEvents();
            }
        }

        private void btnSelectOutputTimeSheet_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Excel Files(*.xls;)|*.xls|All files (*.*)|*.*";
            if (!string.IsNullOrEmpty(txtOutputTimeSheet.Text))
            {
                saveFileDialog.InitialDirectory = txtOutputTimeSheet.Text;
                var outputFile = new FileInfo(txtOutputTimeSheet.Text);
                saveFileDialog.FileName = !string.IsNullOrEmpty(outputFile.Extension) ? outputFile.Name : "";
            }
            else
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputTimeSheet.Text = saveFileDialog.FileName;
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtEndDate.Value = dtStartDate.Value.AddDays(14);
        }
    }
}
