using LINQ_Basics;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Dynamic;
using System.Text.RegularExpressions;

//LINQ Operators
//Some commonly used LINQ operators include:

//Where: Filters elements based on a condition.
//Select: Projects each element of a sequence into a new form.
//OrderBy / OrderByDescending: Sorts elements in ascending/descending order.
//Join: Joins two sequences based on a key.
//GroupBy: Groups elements based on a key.
//Distinct: Removes duplicate elements.
//First / FirstOrDefault: Returns the first element or a default value if none is found.
//Single / SingleOrDefault: Returns a single element or a default value if none or more than one is found.
//Any: Determines if any elements satisfy a condition.
//All: Determines if all elements satisfy a condition.
//Count: Counts the number of elements in a sequence.
//Sum / Min / Max / Average: Performs mathematical operations on elements.

//Query Syntax
//var result = from item in collection
//             where item.Condition
//             orderby item.Property
//             select item;

//Method Syntax
//var result = collection.Where(item => item.Condition)
//                       .OrderBy(item => item.Property)
//                       .Select(item => item);

//LINQ queries are not executed when they are defined. 
//    Instead, they are executed when the query is iterated over, 
//    for example, when using a foreach loop or calling methods


// Sample data
List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500.00, Stock = 10 },
            new Product { Id = 2, Name = "Smartphone", Price = 800.00, Stock = 20 },
            new Product { Id = 3, Name = "Tablet", Price = 500.00, Stock = 15 }
        };

// LINQ query with anonymous type
var productInfo = products.Select(p => new
{
    p.Name,
    p.Price,
    p.Stock,
    IsInStock = p.Stock > 0,
    TotalValue = p.Price * p.Stock
});

// Displaying the results
foreach (var item in productInfo)
{
    Console.WriteLine($"Product: {item.Name}, Price: {item.Price:C}, Stock: {item.Stock}, In Stock: {item.IsInStock}, Total Value: {item.TotalValue:C}");
}

//Array Example
//Scenario: Filter, Select, and Order Numbers in an Array
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filter: Get even numbers
var evenNumbers = numbers.Where(n => n % 2 == 0);

// Select: Project even numbers into a new anonymous type with the original number and its square
var evenNumberSquares = evenNumbers.Select(n => new { Number = n, Square = n * n });

// Order: Order the results by the square in descending order
var orderedSquares = evenNumberSquares.OrderByDescending(x => x.Square);

// Output the results
foreach (var item in orderedSquares)
{
    Console.WriteLine($"Number: {item.Number}, Square: {item.Square}");
}

//List Example
//Scenario: Filter, Select, and Group People by Age
List<Person> people = new List<Person>
{
    new Person { Name = "Alice", Age = 30 },
    new Person { Name = "Bob", Age = 25 },
    new Person { Name = "Charlie", Age = 30 },
    new Person { Name = "David", Age = 35 },
    new Person { Name = "Eve", Age = 25 }
};

// Filter: Get people older than 25
var adults = people.Where(p => p.Age > 25);

// Select: Project into a new anonymous type with just the name and age
var adultNamesAndAges = adults.Select(p => new { p.Name, p.Age });

// Group: Group people by age
var groupedByAge = adultNamesAndAges.GroupBy(p => p.Age);

// Output the results
foreach (var group in groupedByAge)
{
    Console.WriteLine($"Age: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"  Name: {person.Name}");
    }
}



