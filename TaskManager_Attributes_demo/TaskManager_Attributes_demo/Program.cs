using System.Reflection;

namespace TaskManager_Attributes_demo
{
    class Program
    {
        static void Main(string[] args)
        {
                Task task = new Task
                {
                    Title = "Implement Task Management System",
                    Description = "Create a task management system using C# attributes."
                };

                DisplayDeveloperInfo(typeof(Task));

                task.StartTask();
                DisplayDeveloperInfo(typeof(Task).GetMethod("StartTask"));

                task.CompleteTask();
                DisplayDeveloperInfo(typeof(Task).GetMethod("CompleteTask"));
            }

            static void DisplayDeveloperInfo(MemberInfo member)
            {
                object[] attributes = member.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);
                foreach (DeveloperInfoAttribute attr in attributes)
                {
                    Console.WriteLine($"{member.Name} - Developer: {attr.DeveloperName}, Last Modified: {attr.LastModified.ToShortDateString()}");
                }
            }
        }
    }
   
