namespace TimeSheetImport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBackupFile = new System.Windows.Forms.TextBox();
            this.txtTimeSheetTemplate = new System.Windows.Forms.TextBox();
            this.txtOutputTimeSheet = new System.Windows.Forms.TextBox();
            this.btnSelectBackupDataFile = new System.Windows.Forms.Button();
            this.btnSelectTimeSheetTemplate = new System.Windows.Forms.Button();
            this.btnSelectOutputTimeSheet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Data File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time Sheet Template File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Output Time Sheet File:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(293, 270);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBackupFile
            // 
            this.txtBackupFile.Location = new System.Drawing.Point(142, 119);
            this.txtBackupFile.Name = "txtBackupFile";
            this.txtBackupFile.Size = new System.Drawing.Size(331, 20);
            this.txtBackupFile.TabIndex = 5;
            // 
            // txtTimeSheetTemplate
            // 
            this.txtTimeSheetTemplate.Location = new System.Drawing.Point(142, 145);
            this.txtTimeSheetTemplate.Name = "txtTimeSheetTemplate";
            this.txtTimeSheetTemplate.Size = new System.Drawing.Size(331, 20);
            this.txtTimeSheetTemplate.TabIndex = 6;
            // 
            // txtOutputTimeSheet
            // 
            this.txtOutputTimeSheet.Location = new System.Drawing.Point(142, 171);
            this.txtOutputTimeSheet.Name = "txtOutputTimeSheet";
            this.txtOutputTimeSheet.Size = new System.Drawing.Size(331, 20);
            this.txtOutputTimeSheet.TabIndex = 7;
            // 
            // btnSelectBackupDataFile
            // 
            this.btnSelectBackupDataFile.Location = new System.Drawing.Point(479, 117);
            this.btnSelectBackupDataFile.Name = "btnSelectBackupDataFile";
            this.btnSelectBackupDataFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectBackupDataFile.TabIndex = 8;
            this.btnSelectBackupDataFile.Text = "Select";
            this.btnSelectBackupDataFile.UseVisualStyleBackColor = true;
            this.btnSelectBackupDataFile.Click += new System.EventHandler(this.btnSelectBackupDataFile_Click);
            // 
            // btnSelectTimeSheetTemplate
            // 
            this.btnSelectTimeSheetTemplate.Location = new System.Drawing.Point(479, 143);
            this.btnSelectTimeSheetTemplate.Name = "btnSelectTimeSheetTemplate";
            this.btnSelectTimeSheetTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTimeSheetTemplate.TabIndex = 9;
            this.btnSelectTimeSheetTemplate.Text = "Select";
            this.btnSelectTimeSheetTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTimeSheetTemplate.Click += new System.EventHandler(this.btnSelectTimeSheetTemplate_Click);
            // 
            // btnSelectOutputTimeSheet
            // 
            this.btnSelectOutputTimeSheet.Location = new System.Drawing.Point(479, 169);
            this.btnSelectOutputTimeSheet.Name = "btnSelectOutputTimeSheet";
            this.btnSelectOutputTimeSheet.Size = new System.Drawing.Size(75, 23);
            this.btnSelectOutputTimeSheet.TabIndex = 10;
            this.btnSelectOutputTimeSheet.Text = "Select";
            this.btnSelectOutputTimeSheet.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "End Date:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(142, 67);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(197, 20);
            this.dtStartDate.TabIndex = 17;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(142, 93);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(197, 20);
            this.dtEndDate.TabIndex = 18;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 305);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectOutputTimeSheet);
            this.Controls.Add(this.btnSelectTimeSheetTemplate);
            this.Controls.Add(this.btnSelectBackupDataFile);
            this.Controls.Add(this.txtOutputTimeSheet);
            this.Controls.Add(this.txtTimeSheetTemplate);
            this.Controls.Add(this.txtBackupFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBackupFile;
        private System.Windows.Forms.TextBox txtTimeSheetTemplate;
        private System.Windows.Forms.TextBox txtOutputTimeSheet;
        private System.Windows.Forms.Button btnSelectBackupDataFile;
        private System.Windows.Forms.Button btnSelectTimeSheetTemplate;
        private System.Windows.Forms.Button btnSelectOutputTimeSheet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

