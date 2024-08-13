using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace LINQ_Demo_G1
{
    //Simple app to illustrate the use of LINQ
    //LINQ: Language Integrated Query
    //Leverages the System.Linq namesapce
     class Program
    {
        static void Main(string[] args)
        {
            //Sample data>>>> A List of integers from 1 to 10
            List<int> numbers = new List<int> {1,2,3,4,5,6,7,8,9,10 };

            //Syntax for a LINQ (query expression)
            // from: specifies the data source
            // where: applies a filter to the data source
            // select: specifies the result to return

            var evenNumberQuery = from num in numbers //defines the data source (numbers) & the iteration variable (num)
                                  where num % 2 == 0 //filters the numbers, selecting only even numbers
                                  select num;// specifies the result to return >>> only the even numbers

            //output for the above LINQ expression
            Console.WriteLine("Even numbers using the Query Syntax:");
            {
                foreach (var num in evenNumberQuery) 
                {
                    Console.WriteLine(num);
                }
            }

            //LINQ Method Syntax: Make use of the lambda expression
            // Select : looking for the data source
            // Where : is a method that filters the elements based on a condition

            var evenNumbersMethod = numbers.Where(num => num % 2 == 0).Select(num => num);
            //Using the above LINQ method, Where() filters using the lambda expression & .Select() projects each element in the sequence

            //Output of the above query using the LINQ Method()
            Console.WriteLine("\n Even Numbers using the LINQ method");
            foreach (var num in evenNumbersMethod) 
            {
                Console.WriteLine(num);
            }

            //LINQ Query >>> Order numbers in descending order
            //Syntax for a LINQ (query expression)
            // from: specifies the data source
            // orderby: applies a filter to the data source
            // select: specifies the result to return

            var orderedNumberQuery = from num in numbers
                                     orderby num descending
                                     select num;
            Console.WriteLine("\nNumbers in descending order using the Query Syntax");
            foreach (var num in orderedNumberQuery) 
            {
                Console.WriteLine(num);
            }

            //the same query done via a LINQ method way
            var orderedNumberMethod = numbers.OrderByDescending(num => num);
            Console.WriteLine("\nNumbers ordered in Descending via LINQ Method query syntax:");
            foreach (var num in orderedNumberMethod) 
            {
                Console.WriteLine(num);
            }

            //Create a LINQ query for:

            //All LINQ query operations consist of three distinct actions:
            // Step 1: Obtain the data source.
            // Step 2: Create the query.
            // Step 3: Execute the query

            //Select Numbers greater than 5 (Output: 6,7,8,9,10)
            var numbersGreaterThanFive = from num in numbers //step 1
                                         where num > 5 //step 2
                                         select num;

            Console.WriteLine("\n Numbers greater than 5: ");
            foreach (var num in numbersGreaterThanFive) 
            {
                Console.WriteLine(num);// step 3
            }

            //Select Numbers the first 5 numbers (Output: 1,2,3,4,5)
            //Take method is used to take the first 5 elements from the list
            var firstFiveNumbersQuery = (from num in numbers 
                                         select num).Take(5);
            Console.WriteLine("\n First Five Numbers:");
            foreach (var num in firstFiveNumbersQuery) 
            {
                Console.WriteLine(num);
            }








        }
    }
}
