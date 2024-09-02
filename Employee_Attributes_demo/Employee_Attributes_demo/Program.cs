using System.ComponentModel.DataAnnotations;

namespace Employee_Attributes_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Id = "23345";
            emp.FName = "Joe";
            emp.SName = "Blog";
            emp.Email = "joe.blog@gmail.com";
            emp.Phone = "123456";
            emp.Salary = 10000;

            Console.WriteLine(emp.getValues());

            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(emp);

            bool validCheck = Validator.TryValidateObject(emp, context, validationResults, true);

            if (!validCheck)
            {
                foreach (ValidationResult result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("No errors");
            }

            Console.ReadLine();
        }
    }
}
