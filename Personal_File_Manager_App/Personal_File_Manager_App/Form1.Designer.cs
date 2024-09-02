namespace Personal_File_Manager_App
{
    partial class Personal_File_Manager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelDirectoryPath = new Label();
            labelFileName = new Label();
            textBoxDirectoryPath = new TextBox();
            textBoxFileName = new TextBox();
            buttonCreateDirectory = new Button();
            buttonCreateFile = new Button();
            buttonDelete = new Button();
            buttonMoveFile = new Button();
            buttonCopyFile = new Button();
            buttonOpenFile = new Button();
            buttonSaveChanges = new Button();
            textBoxFileContent = new RichTextBox();
            listBoxFiles = new ListBox();
            SuspendLayout();
            // 
            // labelDirectoryPath
            // 
            labelDirectoryPath.AutoSize = true;
            labelDirectoryPath.Location = new Point(112, 40);
            labelDirectoryPath.Name = "labelDirectoryPath";
            labelDirectoryPath.Size = new Size(123, 25);
            labelDirectoryPath.TabIndex = 0;
            labelDirectoryPath.Text = "Directory Path";
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Location = new Point(145, 109);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(90, 25);
            labelFileName.TabIndex = 1;
            labelFileName.Text = "File Name";
            // 
            // textBoxDirectoryPath
            // 
            textBoxDirectoryPath.Location = new Point(270, 37);
            textBoxDirectoryPath.Name = "textBoxDirectoryPath";
            textBoxDirectoryPath.Size = new Size(466, 31);
            textBoxDirectoryPath.TabIndex = 2;
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(270, 106);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(466, 31);
            textBoxFileName.TabIndex = 3;
            // 
            // buttonCreateDirectory
            // 
            buttonCreateDirectory.Location = new Point(12, 190);
            buttonCreateDirectory.Name = "buttonCreateDirectory";
            buttonCreateDirectory.Size = new Size(223, 34);
            buttonCreateDirectory.TabIndex = 4;
            buttonCreateDirectory.Text = "Create Directory";
            buttonCreateDirectory.UseVisualStyleBackColor = true;
            buttonCreateDirectory.Click += buttonCreateDirectory_Click;
            // 
            // buttonCreateFile
            // 
            buttonCreateFile.Location = new Point(12, 259);
            buttonCreateFile.Name = "buttonCreateFile";
            buttonCreateFile.Size = new Size(223, 34);
            buttonCreateFile.TabIndex = 5;
            buttonCreateFile.Text = "Create File";
            buttonCreateFile.UseVisualStyleBackColor = true;
            buttonCreateFile.Click += buttonCreateFile_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(12, 323);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(223, 34);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Delete File/Directory";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonMoveFile
            // 
            buttonMoveFile.Location = new Point(12, 383);
            buttonMoveFile.Name = "buttonMoveFile";
            buttonMoveFile.Size = new Size(223, 34);
            buttonMoveFile.TabIndex = 7;
            buttonMoveFile.Text = "Move File";
            buttonMoveFile.UseVisualStyleBackColor = true;
            buttonMoveFile.Click += buttonMoveFile_Click;
            // 
            // buttonCopyFile
            // 
            buttonCopyFile.Location = new Point(12, 444);
            buttonCopyFile.Name = "buttonCopyFile";
            buttonCopyFile.Size = new Size(223, 34);
            buttonCopyFile.TabIndex = 8;
            buttonCopyFile.Text = "Copy File";
            buttonCopyFile.UseVisualStyleBackColor = true;
            buttonCopyFile.Click += buttonCopyFile_Click;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Location = new Point(12, 521);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(223, 34);
            buttonOpenFile.TabIndex = 9;
            buttonOpenFile.Text = "Open File";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // buttonSaveChanges
            // 
            buttonSaveChanges.Location = new Point(12, 588);
            buttonSaveChanges.Name = "buttonSaveChanges";
            buttonSaveChanges.Size = new Size(223, 34);
            buttonSaveChanges.TabIndex = 10;
            buttonSaveChanges.Text = "Save Changes";
            buttonSaveChanges.UseVisualStyleBackColor = true;
            buttonSaveChanges.Click += buttonSaveChanges_Click;
            // 
            // textBoxFileContent
            // 
            textBoxFileContent.Location = new Point(270, 323);
            textBoxFileContent.Name = "textBoxFileContent";
            textBoxFileContent.Size = new Size(466, 299);
            textBoxFileContent.TabIndex = 11;
            textBoxFileContent.Text = "";
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 25;
            listBoxFiles.Location = new Point(270, 182);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(466, 129);
            listBoxFiles.TabIndex = 12;
            listBoxFiles.SelectedIndexChanged += listBoxFiles_SelectedIndexChanged;
            // 
            // Personal_File_Manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 699);
            Controls.Add(listBoxFiles);
            Controls.Add(textBoxFileContent);
            Controls.Add(buttonSaveChanges);
            Controls.Add(buttonOpenFile);
            Controls.Add(buttonCopyFile);
            Controls.Add(buttonMoveFile);
            Controls.Add(buttonDelete);
            Controls.Add(buttonCreateFile);
            Controls.Add(buttonCreateDirectory);
            Controls.Add(textBoxFileName);
            Controls.Add(textBoxDirectoryPath);
            Controls.Add(labelFileName);
            Controls.Add(labelDirectoryPath);
            Name = "Personal_File_Manager";
            Text = "Personal File Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDirectoryPath;
        private Label labelFileName;
        private TextBox textBoxDirectoryPath;
        private TextBox textBoxFileName;
        private Button buttonCreateDirectory;
        private Button buttonCreateFile;
        private Button buttonDelete;
        private Button buttonMoveFile;
        private Button buttonCopyFile;
        private Button buttonOpenFile;
        private Button buttonSaveChanges;
        private RichTextBox textBoxFileContent;
        private ListBox listBoxFiles;
    }
}
