namespace LoginScreenChangerTray
{
    partial class SettingsChanger
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
            this.lblRotationDelay = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.txtRotationDelay = new System.Windows.Forms.TextBox();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblImageDirectory = new System.Windows.Forms.Label();
            this.txtImageDirectory = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRotationDelay
            // 
            this.lblRotationDelay.AutoSize = true;
            this.lblRotationDelay.Location = new System.Drawing.Point(29, 24);
            this.lblRotationDelay.Name = "lblRotationDelay";
            this.lblRotationDelay.Size = new System.Drawing.Size(77, 13);
            this.lblRotationDelay.TabIndex = 0;
            this.lblRotationDelay.Text = "Rotation Delay";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Location = new System.Drawing.Point(221, 102);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(75, 23);
            this.btnSaveChanges.TabIndex = 1;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.BtnSaveChangesClick);
            // 
            // txtRotationDelay
            // 
            this.txtRotationDelay.Location = new System.Drawing.Point(112, 21);
            this.txtRotationDelay.Name = "txtRotationDelay";
            this.txtRotationDelay.Size = new System.Drawing.Size(100, 20);
            this.txtRotationDelay.TabIndex = 2;
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(218, 24);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(53, 13);
            this.lblSeconds.TabIndex = 3;
            this.lblSeconds.Text = "(seconds)";
            // 
            // lblImageDirectory
            // 
            this.lblImageDirectory.AutoSize = true;
            this.lblImageDirectory.Location = new System.Drawing.Point(29, 64);
            this.lblImageDirectory.Name = "lblImageDirectory";
            this.lblImageDirectory.Size = new System.Drawing.Size(81, 13);
            this.lblImageDirectory.TabIndex = 4;
            this.lblImageDirectory.Text = "Image Directory";
            // 
            // txtImageDirectory
            // 
            this.txtImageDirectory.Location = new System.Drawing.Point(116, 61);
            this.txtImageDirectory.Name = "txtImageDirectory";
            this.txtImageDirectory.Size = new System.Drawing.Size(191, 20);
            this.txtImageDirectory.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSelectFolder.Location = new System.Drawing.Point(313, 59);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 7;
            this.btnSelectFolder.Text = "Pick Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.BtnSelectFolderClick);
            // 
            // SettingsChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 151);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtImageDirectory);
            this.Controls.Add(this.lblImageDirectory);
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.txtRotationDelay);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.lblRotationDelay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsChanger";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Login Screen Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRotationDelay;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.TextBox txtRotationDelay;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblImageDirectory;
        private System.Windows.Forms.TextBox txtImageDirectory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectFolder;
    }
}