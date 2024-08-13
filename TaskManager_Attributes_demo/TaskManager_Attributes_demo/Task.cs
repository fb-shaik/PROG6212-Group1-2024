using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Attributes_demo
{
    [DeveloperInfo("Alice Smith", "2024-08-01")]
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DeveloperInfo("Bob Johnson", "2024-08-05")]
        public void StartTask()
        {
            Console.WriteLine("Task started.");
        }

        [DeveloperInfo("Charlie Brown", "2024-08-07")]
        public void CompleteTask()
        {
            Console.WriteLine("Task completed.");
        }
    }
}
