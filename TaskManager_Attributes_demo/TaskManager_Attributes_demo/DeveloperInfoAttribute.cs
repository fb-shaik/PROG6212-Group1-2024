using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_Attributes_demo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class DeveloperInfoAttribute : Attribute
    {
        public string DeveloperName { get; }
        public DateTime LastModified { get; }

        public DeveloperInfoAttribute(string developerName, string lastModified)
        {
            DeveloperName = developerName;
            LastModified = DateTime.Parse(lastModified);
        }
    }
}