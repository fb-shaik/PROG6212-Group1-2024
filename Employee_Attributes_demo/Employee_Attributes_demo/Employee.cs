using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attributes_demo
{
     class Employee
    {
        private string id;
        private string fName;
        private string sName;
        private string email;
        private string phone;
        private double salary;

        [Required(ErrorMessage = "ID is required")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID must be 13 characters")]
        public string Id { get => id; set => id = value; }

        [Required(ErrorMessage = "First Name is required")]
        public string FName { get => fName; set => fName = value; }

        [Required(ErrorMessage = "Surname Name is required")]
        public string SName { get => sName; set => sName = value; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 characters")]
        public string Phone { get => phone; set => phone = value; }

        [Range(1, 1000000, ErrorMessage = "Salary must be between R1 & R1 mil")]
        public double Salary { get => salary; set => salary = value; }

        [Obsolete("This method is obsolete. Consider UpdatedGetValues")]
        public string getValues() 
        {
            return this.fName;
        }

        public string updatedGetValues()
        {
            return (this.fName + " " + sName);
        }

    }
}
