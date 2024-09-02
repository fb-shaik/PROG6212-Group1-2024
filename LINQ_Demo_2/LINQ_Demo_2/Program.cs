namespace LINQ_Demo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data: List of integers from 1 to 10
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Sample data: List of people with ID and Name
            List<Person> people = new List<Person>
            {
                new Person { ID = 1, Name = "Alice", Age = 30 },
                new Person { ID = 2, Name = "Bob", Age = 35 },
                new Person { ID = 3, Name = "Charlie", Age = 25 },
                new Person { ID = 4, Name = "David", Age = 40 },
                new Person { ID = 5, Name = "Eve", Age = 22 },
                new Person { ID = 6, Name = "Frank", Age = 35 }
            };

            // Sample data: List of orders with PersonID and Product
            List<Order> orders = new List<Order>
            {
                new Order { PersonID = 1, Product = "Laptop" },
                new Order { PersonID = 2, Product = "Smartphone" },
                new Order { PersonID = 3, Product = "Tablet" },
                new Order { PersonID = 4, Product = "Monitor" },
                new Order { PersonID = 5, Product = "Keyboard" },
                new Order { PersonID = 1, Product = "Mouse" },
                new Order { PersonID = 2, Product = "Charger" }
            };

            // 1. LINQ Query Syntax: Group numbers by even and odd
            var groupedNumbersQuery = from num in numbers
                                      group num by num % 2 == 0 into g
                                      select new { Key = g.Key, Numbers = g };

            // Output the grouped numbers
            Console.WriteLine("Grouped numbers by even and odd using Query Syntax:");
            foreach (var group in groupedNumbersQuery)
            {
                Console.WriteLine(group.Key ? "Even:" : "Odd:");
                foreach (var num in group.Numbers)
                {
                    Console.WriteLine(num);
                }
            }

            // 2. LINQ Method Syntax: Group numbers by even and odd
            var groupedNumbersMethod = numbers.GroupBy(num => num % 2 == 0)
                                              .Select(g => new { Key = g.Key, Numbers = g });

            // Output the grouped numbers
            Console.WriteLine("\nGrouped numbers by even and odd using Method Syntax:");
            foreach (var group in groupedNumbersMethod)
            {
                Console.WriteLine(group.Key ? "Even:" : "Odd:");
                foreach (var num in group.Numbers)
                {
                    Console.WriteLine(num);
                }
            }

            // 3. LINQ Query Syntax: Join people with their orders
            var joinQuery = from person in people
                            join order in orders on person.ID equals order.PersonID
                            select new { person.Name, order.Product };

            // Output the joined data
            Console.WriteLine("\nJoin people with their orders using Query Syntax:");
            foreach (var item in joinQuery)
            {
                Console.WriteLine($"{item.Name} ordered {item.Product}");
            }

            // 4. LINQ Method Syntax: Join people with their orders
            var joinMethod = people.Join(orders,
                                         person => person.ID,
                                         order => order.PersonID,
                                         (person, order) => new { person.Name, order.Product });

            // Output the joined data
            Console.WriteLine("\nJoin people with their orders using Method Syntax:");
            foreach (var item in joinMethod)
            {
                Console.WriteLine($"{item.Name} ordered {item.Product}");
            }

            // 5. LINQ Query Syntax: Aggregate - Sum of all numbers
            var sumQuery = (from num in numbers
                            select num).Sum();

            // Output the sum of numbers using Query Syntax
            Console.WriteLine($"\nSum of all numbers using Query Syntax: {sumQuery}");

            // 6. LINQ Method Syntax: Aggregate - Sum of all numbers
            var sumMethod = numbers.Sum();

            // Output the sum of numbers using Method Syntax
            Console.WriteLine($"Sum of all numbers using Method Syntax: {sumMethod}");

            // 7. LINQ Query Syntax: Average age of people
            var averageAgeQuery = (from person in people
                                   select person.Age).Average();

            // Output the average age using Query Syntax
            Console.WriteLine($"\nAverage age using Query Syntax: {averageAgeQuery}");

            // 8. LINQ Method Syntax: Average age of people
            var averageAgeMethod = people.Average(person => person.Age);

            // Output the average age using Method Syntax
            Console.WriteLine($"Average age using Method Syntax: {averageAgeMethod}");
        }
    }
}
