using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes_Employee_App_G1
{
    class Employee
    {
        //6 fields: ID, Fname, Sname, Phone, Email, Salary
        private string id;
        private string fName;
        private string sName;
        private string email;
        private string phone;
        private double salary;

        [Required(ErrorMessage = "ID is a required field")]
        [StringLength(13, MinimumLength = 13, ErrorMessage ="ID must be 13 characters")]
        public string Id { get => id; set => id = value; } //this is an element

        [Required(ErrorMessage = "First Name is required")]
        public string FName { get => fName; set => fName = value; }

        [Required(ErrorMessage = "Surname is required")]
        public string SName { get => sName; set => sName = value; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "Phone number should be 10 characters")]
        [Phone]
        public string Phone { get => phone; set => phone = value; }

        [Range (1, 1000000, ErrorMessage ="Salary must be between R1.00 & R1 mill")]
        public double Salary { get => salary; set => salary = value; }

        [Obsolete("This method is obsolete. Consider the UpdatedGetValues()")]
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

/*Attributes are declarative tags that is used to cinvey information to runtime about the behaviours of 
 * various elements in the code/project
 * Could be used for classes, methods, structures, enumerators, assemblies 
 * depicted by using the [] tag above the element in question
 * Adds meta data 
 * .Net Framework has 2 types of attributes: PreDefined & Custom Built attributes
 * 
 * Syntax: 
 * [attribute(positional_parameter, name_paramter = value, .........)]
 *  element (class/method/property)
 *  
 *  In this build we used:
 *  Required: Ensure that the fields are not null / empty
 *  StringLenght: enforces the rule for the lenght of the string input
 *  Email/Phone: Validates the format for Email/Phone
 *  Range: Ensures the values is within the specified range
 */
