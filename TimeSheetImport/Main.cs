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
                TimeSheetBackup = new TimeSheetBackup(txtBackupFile.Text);
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
    }
}
