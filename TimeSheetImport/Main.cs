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

namespace TimeSheetImport
{
    internal partial class Main : Form
    {
        internal TimeSheetBackup TimeSheetBackup;
        internal TimeSheetExcel TimeSheetExcel;

        internal Main()
        {
            InitializeComponent();

            loadDefaultsFromRegistry();
        }

        private void btnSelectBackupDataFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBackupFile.Text = openFileDialog.FileName;
            }
        }

        private void loadDefaultsFromRegistry()
        {
            txtBackupFile.Text = RegistryHelper.Read(RegistryHelper.Keys.BackupDataFilePath);
            txtTimeSheetTemplate.Text = RegistryHelper.Read(RegistryHelper.Keys.TimeSheetTemplateFilePath);
            txtOutputTimeSheet.Text = RegistryHelper.Read(RegistryHelper.Keys.OutputTimeSheetFolderPath);
            dtStartDate.Text = RegistryHelper.Read(RegistryHelper.Keys.StartDate);
            dtEndDate.Text = RegistryHelper.Read(RegistryHelper.Keys.EndDate);
        }

        private void saveDefaultsToRegistry()
        {
            RegistryHelper.Write(RegistryHelper.Keys.BackupDataFilePath, txtBackupFile.Text);
            RegistryHelper.Write(RegistryHelper.Keys.TimeSheetTemplateFilePath, txtTimeSheetTemplate.Text);
            RegistryHelper.Write(RegistryHelper.Keys.OutputTimeSheetFolderPath, !string.IsNullOrEmpty(txtOutputTimeSheet.Text) ? (new DirectoryInfo(txtOutputTimeSheet.Text)).Parent.ToString() : "");
            RegistryHelper.Write(RegistryHelper.Keys.StartDate, dtStartDate.Text);
            RegistryHelper.Write(RegistryHelper.Keys.EndDate, dtEndDate.Text);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveDefaultsToRegistry();
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
                TimeSheetBackup = new TimeSheetBackup(txtBackupFile.Text);
                TimeSheetExcel = new TimeSheetExcel(txtTimeSheetTemplate.Text);
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
    }
}
