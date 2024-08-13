using System.ComponentModel.DataAnnotations;

namespace Attributes_Employee_App_G1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an instance of the Employee class
            Employee emp = new Employee();
            emp.Id = "1234567891011";
            emp.FName = "Joe";
            emp.SName = "Blog";
            emp.Email = "joe.blog@gmail.com";
            emp.Phone = "1234567890";
            emp.Salary = 10000;


            Console.WriteLine(emp.getValues());

            Console.WriteLine(emp.updatedGetValues());

            //ValidationResult class that represents the result of a validation request
            //List<ValidationResult>: initializing an empty list that will store any validation errors/results found
            List<ValidationResult> validationResults = new List<ValidationResult>();

            //ValidationContext provides a context in which the validation is performed
            //It will include information about the object in question
            ValidationContext context = new ValidationContext(emp);

            bool validCheck = Validator.TryValidateObject(emp, context, validationResults, true);
            //Validator.TryValidateObject method that validates the object based on the attributes  set
            // Passed along 4 parameters:
            // emp: object to validate
            // context: necessary context for validation
            // validationResults: the list to hold the validation results (errors) found
            // true: indicates whether all properties are valid

            if (!validCheck)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            else {
                Console.WriteLine("No errors found!");
            }
                Console.ReadLine();
        }
    }
}
