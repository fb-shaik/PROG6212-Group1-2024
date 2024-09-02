// Declare a dynamic variable and assign a string value "Hello"
dynamic variable = "Hello";
// Output the value of the variable, which is a string: Hello
Console.WriteLine(variable);  // Output: Hello

// Change the value of the dynamic variable to an integer 5
variable = 5;
// Output the new value of the variable, which is now an integer: 5
Console.WriteLine(variable);  // Output: 5

// Declare an anonymous type with properties Name and Age, and assign values to them
var person = new { Name = "John", Age = 30 };
// Output the value of the Name property of the anonymous type: John
Console.WriteLine(person.Name);  // Output: John
// Output the value of the Age property of the anonymous type: 30
Console.WriteLine(person.Age);   // Output: 30

// Create two instances of the Point class with specified coordinates
var point1 = new Point(1, 2);
var point2 = new Point(3, 4);
// Add the two Point instances using the overloaded + operator
var result = point1 + point2;

// Output the result of the addition, which is a new Point with coordinates (4, 6)
Console.WriteLine($"({result.X}, {result.Y})");  // Output: (4, 6)

// Define the Point class
public class Point
{
    // Properties to hold the X and Y coordinates
    public int X { get; set; }
    public int Y { get; set; }

    // Constructor to initialize the X and Y coordinates
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Overload the + operator to add two Point instances
    public static Point operator +(Point a, Point b)
    {
        // Return a new Point instance with the sum of the X and Y coordinates
        return new Point(a.X + b.X, a.Y + b.Y);
    }
}
