namespace FileHandlingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the allowed file types
            string[] allowedExtensions = { ".txt", ".pdf", ".docx" };

            Console.WriteLine("Please enter the path of the file you want to upload:");
            string filePath = Console.ReadLine();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Get the file extension
                string fileExtension = Path.GetExtension(filePath).ToLower();

                // Check if the file extension is allowed
                if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    Console.WriteLine("File type is allowed. Proceeding with the upload...");

                    // Upload the file by moving it to a specific directory
                    string uploadDirectory = "uploads";
                    Directory.CreateDirectory(uploadDirectory);
                    string destinationPath = Path.Combine(uploadDirectory, Path.GetFileName(filePath));

                    File.Copy(filePath, destinationPath, true);
                    Console.WriteLine("File uploaded successfully!");

                    // Proceed with file handling operations
                    HandleFile(destinationPath);
                }
                else
                {
                    Console.WriteLine("Error: This file type is not allowed.");
                }
            }
            else
            {
                Console.WriteLine("Error: File does not exist.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void HandleFile(string filePath)
        {
            // 1. Reading from a File using File.ReadAllText
            string content = File.ReadAllText(filePath);
            Console.WriteLine("\nFile Content:");
            Console.WriteLine(content);

            // 2. Appending to a File using File.AppendAllText
            Console.WriteLine("\nAppending more text to the file...");
            File.AppendAllText(filePath, "\nThis text is appended to the file.");

            // Reading the updated content
            content = File.ReadAllText(filePath);
            Console.WriteLine("\nUpdated File Content:");
            Console.WriteLine(content);

            // 3. Using StreamReader to read file line by line
            Console.WriteLine("\nReading file line by line:");
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            // 4. Displaying File Properties using FileInfo
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine("\nFile Properties:");
            Console.WriteLine($"File Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
            Console.WriteLine($"Last Access Time: {fileInfo.LastAccessTime}");
            Console.WriteLine($"Last Write Time: {fileInfo.LastWriteTime}");

            // 5. Error Handling: Trying to read a non-existent file
            try
            {
                Console.WriteLine("\nAttempting to read from a non-existent file...");
                string nonExistentFileContent = File.ReadAllText("nonExistentFile.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            // Optional: Deleting the file
            Console.WriteLine("\nDo you want to delete the uploaded file? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                File.Delete(filePath);
                Console.WriteLine("File deleted.");
            }
            else
            {
                Console.WriteLine("File retained.");
            }
        }
    }
}