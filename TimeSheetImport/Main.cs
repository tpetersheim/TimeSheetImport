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
        }

        private void btnSelectBackupDataFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupFile.Text = openFileDialog.FileName;
            }
        }

        private void loadLastSettings()
        {
            txtBackupFile.Text = Properties.Settings.Default.BackupDataFilePath;
            txtTimeSheetTemplate.Text = Properties.Settings.Default.TimeSheetTemplateFilePath;
            txtOutputTimeSheet.Text = !string.IsNullOrEmpty(Properties.Settings.Default.OutputTimeSheetFolderPath) ? Path.Combine(Properties.Settings.Default.OutputTimeSheetFolderPath, "{0}.xls".With(DateTime.Now.ToString("yyyy-MM-dd"))) : Properties.Settings.Default.OutputTimeSheetFolderPath;
            dtStartDate.Value = Properties.Settings.Default.StartDate;
            dtEndDate.Value = Properties.Settings.Default.EndDate;
        }

        private void saveLastSettings()
        {
            Properties.Settings.Default.BackupDataFilePath = txtBackupFile.Text;
            Properties.Settings.Default.TimeSheetTemplateFilePath = txtTimeSheetTemplate.Text;
            if (FileHelper.IsValidFileName(txtOutputTimeSheet.Text))
            {
                var outputFile = new FileInfo(txtOutputTimeSheet.Text);
                Properties.Settings.Default.OutputTimeSheetFolderPath = !string.IsNullOrEmpty(outputFile.Extension) ? Directory.GetParent(txtOutputTimeSheet.Text).ToString() : txtOutputTimeSheet.Text;
            }
            Properties.Settings.Default.StartDate = dtStartDate.Value;
            Properties.Settings.Default.EndDate = dtEndDate.Value;
            Properties.Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveLastSettings();
            if (TimeSheetExcel != null && TimeSheetExcel.AnyFileOpen)
            {
                TimeSheetExcel.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectTimeSheetTemplate_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTimeSheetTemplate.Text = openFileDialog.FileName;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (validateInputs())
            {
                parseFiles();
                writeEntriesToTimeSheet();
                TimeSheetExcel.SaveAs(txtOutputTimeSheet.Text);
                TimeSheetExcel.Close();
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
            if (!Directory.Exists(outputFileParentPath))
            {
                try
                {
                    Directory.CreateDirectory(outputFileParentPath);
                }
                catch (Exception exception)
                {
                    MessageHelper.ShowError(exception, "Cannot create save file directory");
                    return false;
                }
            }

            return true;
        }

        private void parseFiles()
        {
            TimeSheetBackup = new TimeSheetBackup(txtBackupFile.Text);
            TimeSheetExcel = new TimeSheetExcel(txtTimeSheetTemplate.Text);
        }

        private void writeEntriesToTimeSheet()
        {
            TimeSheetExcel.WriteEntry(
                new TimeSheetExcelEntry
                {
                    Date = DateTime.Now,
                    Hours = new TimeSpan(3, 0, 0),
                    Item = new TimeSheetExcelItem { Name = "Test Item" },
                    Job = new TimeSheetExcelJob { Name = "Test Job" },
                    Notes = "Test notes"
                }
            );
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
    }
}
