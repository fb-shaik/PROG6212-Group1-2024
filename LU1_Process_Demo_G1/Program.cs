using System.Diagnostics; //Import needed to use the Process class

namespace LU1_Process_Demo_G1
{
     class Program
    {
        static void Main(string[] args)
        {
            //Process class is a built-in call from the System.Diagnostics namespace
            //Create an instance of the Process class
            Process process = new Process();

            //Set the file name to start the Notepad application
            process.StartInfo.FileName = "notepad.exe";
            
            //Start the process: Open up Notepad on the device
            process.Start();

            //Get all the processess/treads running with the name 'notepad'
            Process[] processes = Process.GetProcessesByName("notepad");
            foreach (var proc in processes) 
            { 
                //Print the process ID to the console
                Console.WriteLine($"Process ID: {proc.Id}");
            }

        }
    }
}
