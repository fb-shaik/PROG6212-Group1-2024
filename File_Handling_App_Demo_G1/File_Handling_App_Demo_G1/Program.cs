using System.IO;

namespace File_Handling_App_Demo_G1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the System.IO tutorial!");
            Console.WriteLine("1. File Operations (Create, Write, Read)");
            Console.WriteLine("2. FileInfo Example");
            Console.WriteLine("3. DirectoryInfo Example");
            Console.WriteLine("4. StreamReader and StreamWriter Example");
            Console.WriteLine("5. Exit");

            while (true)
            {
                Console.Write("\nChoose an option (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        FileOperations();
                        break;
                    case "2":
                        FileInfoExample();
                        break;
                    case "3":
                        DirectoryInfoExample();
                        break;
                    case "4":
                        StreamReaderWriterExample();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the app. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please choose again.");
                        break;
                }
            }
        }

        // Methods for each of the above options
        static void FileOperations()
        {
            string filePath = "example.txt";
            string content = "Hello, this is me!";

            //Create & write to the file
            File.WriteAllText(filePath, content);
            Console.WriteLine($"File '{filePath}' created & written to.");

            //Read from the file
            string readText = File.ReadAllText(filePath);
            Console.WriteLine("Content of the file: ");
            Console.WriteLine(readText);
        }

        static void FileInfoExample()
        {
            string filePath = "example.txt";
            //Create an object to use the FileInfo class is needed
            FileInfo fileInfo = new FileInfo(filePath); ;
            using (StreamWriter writer = fileInfo.CreateText()) 
            {
                writer.WriteLine("This File is created using FileInfo class");
            }
            Console.WriteLine($"File '{filePath}' created using FileInfo");
            //display the fileinfo found 
            Console.WriteLine($"\nFile Name: {fileInfo.Name}" );
            Console.WriteLine($"\nFile Size: {fileInfo.Length} bytes");
            Console.WriteLine($"\nFile Creation Time: {fileInfo.CreationTime}");

        }

        static void DirectoryInfoExample()
        {
            string directoryPath = "MyDirectory";
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            directoryInfo.Create();
            Console.WriteLine($"Directory has been created called '{directoryPath}'");

            //create a subdirectory (folder within a folder)
            directoryInfo.CreateSubdirectory("Sub-Directory");
            Console.WriteLine("Sub-Directory called Sub-Directory was created");

            //List of all the directories created
            Console.WriteLine("List of Directories in this build");
            foreach (var dir in directoryInfo.GetDirectories()) 
            {
                Console.WriteLine($"Directory: {dir.Name}");
            }
            foreach (var file in directoryInfo.GetFiles()) 
            {
                Console.WriteLine($"Files: {file.Name}");
            }


        }

        static void StreamReaderWriterExample()
        {
            string filePath= "stream_example.txt";

            //write to the file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            { 
                writer.WriteLine("This line was written using the StreamWriter Class");
            }
            Console.WriteLine($"File '{filePath}' written using StreamWriter");

            //Read from the file using StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            { 
                string line;
                Console.WriteLine("Reading from the file using the StreamReader");
                while ((line = reader.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}

/*Key Classes in the System.IO
 *
 *File - static methods for creating, copying, deleting, moving & opening files
 *we don't need to instantiate the File class for the static method
 *File.Create(string path)
 *File.Delete(string path)
 *File.Exists(string path)
 *File.Read(string path)
 *File.Write(string path)
 *
 *FileInfo - provided instance methods for creating, copying, deleting, moving & opening files
 *Unlike the File Class, we need to create an instance of the FileInfo class to use the methods
 *FileInfo.CopyTo(string destFileName)
 *FileInfo.Delete()
 *FileInfo.MoveTo(string destFileName)
 *FileInfo.OpenRead()
 *
 *Directory - provide static methods creating, moving, delete, exists
 *DirectoryInfo - instance method version of the above
 *
 *Path - methods that can be used for manipulating 
 *strings that contain file or directory path info
 *
 *Stream - abstract class 
 *used to read/write bytes whether its to a file, memory or network resource
 *(StreamReader & StreamWriter)
 *
 */
