namespace Personal_File_Manager_App
{
    public partial class Personal_File_Manager : Form
    {
        public Personal_File_Manager()
        {
            InitializeComponent();
        }

        private void buttonCreateDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBoxDirectoryPath.Text;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Directory created successfully.");
                    LoadFilesAndDirectories();
                }
                else
                {
                    MessageBox.Show("Directory already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the file name from the text box and ensure it has a .txt extension
                string fileName = textBoxFileName.Text;
                if (!fileName.EndsWith(".txt"))
                {
                    fileName += ".txt";
                }

                // Combine the directory path with the file name
                string path = Path.Combine(textBoxDirectoryPath.Text, fileName);

                // Check if the file exists, and if not, create it
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    MessageBox.Show("Text file created successfully.");
                    LoadFilesAndDirectories();
                }
                else
                {
                    MessageBox.Show("File already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(textBoxDirectoryPath.Text, textBoxFileName.Text);

                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    MessageBox.Show("Directory deleted successfully.");
                }
                else if (File.Exists(path))
                {
                    File.Delete(path);
                    MessageBox.Show("File deleted successfully.");
                }
                else
                {
                    MessageBox.Show("File or directory does not exist.");
                }

                LoadFilesAndDirectories();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonMoveFile_Click(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Path.Combine(textBoxDirectoryPath.Text, textBoxFileName.Text);
                string destinationPath = Path.Combine(textBoxDirectoryPath.Text, "NewDirectory", textBoxFileName.Text);

                if (File.Exists(sourcePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(destinationPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    }

                    File.Move(sourcePath, destinationPath);
                    MessageBox.Show("File moved successfully.");
                    LoadFilesAndDirectories();
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonCopyFile_Click(object sender, EventArgs e)
        {
            try
            {
                string sourcePath = Path.Combine(textBoxDirectoryPath.Text, textBoxFileName.Text);
                string destinationPath = Path.Combine(textBoxDirectoryPath.Text, "CopyOf" + textBoxFileName.Text);

                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath);
                    MessageBox.Show("File copied successfully.");
                    LoadFilesAndDirectories();
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(textBoxDirectoryPath.Text, textBoxFileName.Text);

                if (File.Exists(path))
                {
                    textBoxFileContent.Text = File.ReadAllText(path);
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(textBoxDirectoryPath.Text, textBoxFileName.Text);

                if (File.Exists(path))
                {
                    File.WriteAllText(path, textBoxFileContent.Text);
                    MessageBox.Show("Changes saved successfully.");
                }
                else
                {
                    MessageBox.Show("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected = listBoxFiles.SelectedItem.ToString();
                textBoxFileName.Text = selected;

                string path = Path.Combine(textBoxDirectoryPath.Text, selected);
                if (File.Exists(path))
                {
                    textBoxFileContent.Text = File.ReadAllText(path);
                }
                else
                {
                    textBoxFileContent.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LoadFilesAndDirectories()
        {
            try
            {
                string path = textBoxDirectoryPath.Text;
                listBoxFiles.Items.Clear();

                if (Directory.Exists(path))
                {
                    string[] directories = Directory.GetDirectories(path);
                    string[] files = Directory.GetFiles(path);

                    foreach (var directory in directories)
                    {
                        listBoxFiles.Items.Add(Path.GetFileName(directory));
                    }

                    foreach (var file in files)
                    {
                        listBoxFiles.Items.Add(Path.GetFileName(file));
                    }
                }
                else
                {
                    MessageBox.Show("Directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
