﻿namespace TimeSheetImport
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.txtTimeSheetExcelFile = new System.Windows.Forms.TextBox();
            this.txtOutputTimeSheet = new System.Windows.Forms.TextBox();
            this.btnSelectBackupDataFile = new System.Windows.Forms.Button();
            this.btnSelectTimeSheetExcelFile = new System.Windows.Forms.Button();
            this.btnSelectOutputTimeSheet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.rchTxtInstructions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Data File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time Sheet Excel File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output Time Sheet File:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(321, 205);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(240, 205);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Location = new System.Drawing.Point(142, 105);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(387, 20);
            this.txtBackupFile.TabIndex = 5;
            // 
            // txtTimeSheetExcelFile
            // 
            this.txtTimeSheetExcelFile.Location = new System.Drawing.Point(142, 131);
            this.txtTimeSheetExcelFile.Name = "txtTimeSheetExcelFile";
            this.txtTimeSheetExcelFile.Size = new System.Drawing.Size(387, 20);
            this.txtTimeSheetExcelFile.TabIndex = 6;
            // 
            // txtOutputTimeSheet
            // 
            this.txtOutputTimeSheet.Location = new System.Drawing.Point(142, 157);
            this.txtOutputTimeSheet.Name = "txtOutputTimeSheet";
            this.txtOutputTimeSheet.Size = new System.Drawing.Size(387, 20);
            this.txtOutputTimeSheet.TabIndex = 7;
            // 
            // btnSelectBackupDataFile
            // 
            this.btnSelectBackupDataFile.Location = new System.Drawing.Point(535, 103);
            this.btnSelectBackupDataFile.Name = "btnSelectBackupDataFile";
            this.btnSelectBackupDataFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectBackupDataFile.TabIndex = 8;
            this.btnSelectBackupDataFile.Text = "Select";
            this.btnSelectBackupDataFile.UseVisualStyleBackColor = true;
            this.btnSelectBackupDataFile.Click += new System.EventHandler(this.btnSelectBackupDataFile_Click);
            // 
            // btnSelectTimeSheetExcelFile
            // 
            this.btnSelectTimeSheetExcelFile.Location = new System.Drawing.Point(535, 129);
            this.btnSelectTimeSheetExcelFile.Name = "btnSelectTimeSheetExcelFile";
            this.btnSelectTimeSheetExcelFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTimeSheetExcelFile.TabIndex = 9;
            this.btnSelectTimeSheetExcelFile.Text = "Select";
            this.btnSelectTimeSheetExcelFile.UseVisualStyleBackColor = true;
            this.btnSelectTimeSheetExcelFile.Click += new System.EventHandler(this.btnSelectTimeSheetExcelFile_Click);
            // 
            // btnSelectOutputTimeSheet
            // 
            this.btnSelectOutputTimeSheet.Location = new System.Drawing.Point(535, 155);
            this.btnSelectOutputTimeSheet.Name = "btnSelectOutputTimeSheet";
            this.btnSelectOutputTimeSheet.Size = new System.Drawing.Size(75, 23);
            this.btnSelectOutputTimeSheet.TabIndex = 10;
            this.btnSelectOutputTimeSheet.Text = "Select";
            this.btnSelectOutputTimeSheet.UseVisualStyleBackColor = true;
            this.btnSelectOutputTimeSheet.Click += new System.EventHandler(this.btnSelectOutputTimeSheet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "End Date:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(142, 53);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(197, 20);
            this.dtStartDate.TabIndex = 17;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(142, 79);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(197, 20);
            this.dtEndDate.TabIndex = 18;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // rchTxtInstructions
            // 
            this.rchTxtInstructions.BackColor = System.Drawing.SystemColors.Control;
            this.rchTxtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchTxtInstructions.Location = new System.Drawing.Point(12, 12);
            this.rchTxtInstructions.Name = "rchTxtInstructions";
            this.rchTxtInstructions.ReadOnly = true;
            this.rchTxtInstructions.Size = new System.Drawing.Size(598, 35);
            this.rchTxtInstructions.TabIndex = 20;
            this.rchTxtInstructions.Text = "Import the backup data file from the Timesheet - Time Tracker Android application" +
    ".  \nExport the entries an Excel time sheet template file.";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 240);
            this.Controls.Add(this.rchTxtInstructions);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectOutputTimeSheet);
            this.Controls.Add(this.btnSelectTimeSheetExcelFile);
            this.Controls.Add(this.btnSelectBackupDataFile);
            this.Controls.Add(this.txtOutputTimeSheet);
            this.Controls.Add(this.txtTimeSheetExcelFile);
            this.Controls.Add(this.txtBackupFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(638, 278);
            this.MinimumSize = new System.Drawing.Size(638, 278);
            this.Name = "Main";
            this.Text = "Time Sheet Importer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.TextBox txtTimeSheetExcelFile;
        private System.Windows.Forms.TextBox txtOutputTimeSheet;
        private System.Windows.Forms.Button btnSelectBackupDataFile;
        private System.Windows.Forms.Button btnSelectTimeSheetExcelFile;
        private System.Windows.Forms.Button btnSelectOutputTimeSheet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.RichTextBox rchTxtInstructions;
    }
}

