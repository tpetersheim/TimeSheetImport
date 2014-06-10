namespace TimeSheetImport
{
    partial class ImportProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportProgress));
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.lblConstImporting = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentImportIndex = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalEntries = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarImport
            // 
            this.progressBarImport.Location = new System.Drawing.Point(46, 30);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(242, 23);
            this.progressBarImport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarImport.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(83, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOkay.Enabled = false;
            this.btnOkay.Location = new System.Drawing.Point(164, 87);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(75, 23);
            this.btnOkay.TabIndex = 22;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // lblConstImporting
            // 
            this.lblConstImporting.AutoSize = true;
            this.lblConstImporting.Location = new System.Drawing.Point(43, 9);
            this.lblConstImporting.Name = "lblConstImporting";
            this.lblConstImporting.Size = new System.Drawing.Size(50, 13);
            this.lblConstImporting.TabIndex = 23;
            this.lblConstImporting.Text = "Importing";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(43, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Import Status";
            // 
            // lblCurrentImportIndex
            // 
            this.lblCurrentImportIndex.AutoSize = true;
            this.lblCurrentImportIndex.Location = new System.Drawing.Point(95, 9);
            this.lblCurrentImportIndex.Name = "lblCurrentImportIndex";
            this.lblCurrentImportIndex.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentImportIndex.TabIndex = 25;
            this.lblCurrentImportIndex.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "of";
            // 
            // lblTotalEntries
            // 
            this.lblTotalEntries.AutoSize = true;
            this.lblTotalEntries.Location = new System.Drawing.Point(128, 9);
            this.lblTotalEntries.Name = "lblTotalEntries";
            this.lblTotalEntries.Size = new System.Drawing.Size(19, 13);
            this.lblTotalEntries.TabIndex = 27;
            this.lblTotalEntries.Text = "20";
            // 
            // ImportProgress
            // 
            this.AcceptButton = this.btnOkay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(334, 122);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalEntries);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCurrentImportIndex);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblConstImporting);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBarImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 160);
            this.MinimizeBox = false;
            this.Name = "ImportProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportProgress";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar progressBarImport;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOkay;
        private System.Windows.Forms.Label lblConstImporting;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblCurrentImportIndex;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTotalEntries;
    }
}