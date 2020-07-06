namespace CC_Autofiller
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.openExcelButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.classesComboBox = new System.Windows.Forms.ComboBox();
            this.classLabel = new System.Windows.Forms.Label();
            this.excelFileLabel = new System.Windows.Forms.Label();
            this.fileDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExcelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timePeriodComboBox = new System.Windows.Forms.ComboBox();
            this.timePeriodLabel = new System.Windows.Forms.Label();
            this.gradeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.gradeTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openExcelButton
            // 
            this.openExcelButton.Location = new System.Drawing.Point(24, 145);
            this.openExcelButton.Name = "openExcelButton";
            this.openExcelButton.Size = new System.Drawing.Size(126, 23);
            this.openExcelButton.TabIndex = 0;
            this.openExcelButton.Text = "Open Excel";
            this.openExcelButton.UseVisualStyleBackColor = true;
            this.openExcelButton.Click += new System.EventHandler(this.OpenExcelButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(529, 78);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(191, 22);
            this.usernameTextBox.TabIndex = 1;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(526, 58);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(73, 17);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(526, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(69, 17);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(529, 140);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(191, 22);
            this.passwordTextBox.TabIndex = 4;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(529, 184);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // classesComboBox
            // 
            this.classesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.classesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.classesComboBox.FormattingEnabled = true;
            this.classesComboBox.Location = new System.Drawing.Point(173, 56);
            this.classesComboBox.Name = "classesComboBox";
            this.classesComboBox.Size = new System.Drawing.Size(121, 24);
            this.classesComboBox.Sorted = true;
            this.classesComboBox.TabIndex = 6;
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(170, 36);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(42, 17);
            this.classLabel.TabIndex = 7;
            this.classLabel.Text = "Class";
            // 
            // excelFileLabel
            // 
            this.excelFileLabel.AutoSize = true;
            this.excelFileLabel.Location = new System.Drawing.Point(21, 96);
            this.excelFileLabel.Name = "excelFileLabel";
            this.excelFileLabel.Size = new System.Drawing.Size(34, 17);
            this.excelFileLabel.TabIndex = 8;
            this.excelFileLabel.Text = "File:";
            // 
            // fileDirectoryTextBox
            // 
            this.fileDirectoryTextBox.Location = new System.Drawing.Point(24, 117);
            this.fileDirectoryTextBox.Name = "fileDirectoryTextBox";
            this.fileDirectoryTextBox.Size = new System.Drawing.Size(270, 22);
            this.fileDirectoryTextBox.TabIndex = 9;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(300, 116);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExcelOpenFileDialog
            // 
            this.ExcelOpenFileDialog.FileName = "openFileDialog1";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(24, 58);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(109, 22);
            this.dateTimePicker.TabIndex = 11;
            this.dateTimePicker.Value = new System.DateTime(2019, 12, 17, 17, 47, 33, 0);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(21, 36);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(38, 17);
            this.dateLabel.TabIndex = 12;
            this.dateLabel.Text = "Date";
            // 
            // timePeriodComboBox
            // 
            this.timePeriodComboBox.DisplayMember = "HJ1";
            this.timePeriodComboBox.FormattingEnabled = true;
            this.timePeriodComboBox.Location = new System.Drawing.Point(24, 300);
            this.timePeriodComboBox.Name = "timePeriodComboBox";
            this.timePeriodComboBox.Size = new System.Drawing.Size(121, 24);
            this.timePeriodComboBox.TabIndex = 13;
            // 
            // timePeriodLabel
            // 
            this.timePeriodLabel.AutoSize = true;
            this.timePeriodLabel.Location = new System.Drawing.Point(24, 280);
            this.timePeriodLabel.Name = "timePeriodLabel";
            this.timePeriodLabel.Size = new System.Drawing.Size(84, 17);
            this.timePeriodLabel.TabIndex = 14;
            this.timePeriodLabel.Text = "Time Period";
            // 
            // gradeTypeComboBox
            // 
            this.gradeTypeComboBox.FormattingEnabled = true;
            this.gradeTypeComboBox.Location = new System.Drawing.Point(24, 210);
            this.gradeTypeComboBox.Name = "gradeTypeComboBox";
            this.gradeTypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.gradeTypeComboBox.TabIndex = 15;
            this.gradeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.GradeTypeComboBox_SelectedIndexChanged);
            // 
            // gradeTypeLabel
            // 
            this.gradeTypeLabel.AutoSize = true;
            this.gradeTypeLabel.Location = new System.Drawing.Point(21, 190);
            this.gradeTypeLabel.Name = "gradeTypeLabel";
            this.gradeTypeLabel.Size = new System.Drawing.Size(84, 17);
            this.gradeTypeLabel.TabIndex = 16;
            this.gradeTypeLabel.Text = "Grade Type";
            // 
            // Form1
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gradeTypeLabel);
            this.Controls.Add(this.gradeTypeComboBox);
            this.Controls.Add(this.timePeriodLabel);
            this.Controls.Add(this.timePeriodComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.fileDirectoryTextBox);
            this.Controls.Add(this.excelFileLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.classesComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.openExcelButton);
            this.Name = "Form1";
            this.Text = "CC Autofill";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openExcelButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox classesComboBox;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label excelFileLabel;
        private System.Windows.Forms.TextBox fileDirectoryTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog ExcelOpenFileDialog;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.ComboBox timePeriodComboBox;
        private System.Windows.Forms.Label timePeriodLabel;
        private System.Windows.Forms.ComboBox gradeTypeComboBox;
        private System.Windows.Forms.Label gradeTypeLabel;
    }
}

