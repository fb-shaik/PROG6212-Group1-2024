//Simple app to show how dynamic, anonymous type & operator overloading work

//Dynamic Type: uses keyword 'dynamic
//Syntax: dynamic variableName = value;

//Declare a dynamic variable & assign a string value 'Hello'
dynamic variable = "Hello";

//output the above
Console.WriteLine(variable);//Output: Hello

//change the value of the dynamic variable to an integer 5
variable = 5;
//output the above
Console.WriteLine(variable);//Output: 5

//Anonymous Types: these are immutable, properties are read-only
//Syntax: var anonObject = new {Property1 = value1, Property2 = value2};

//Declare an anonymous type with properties Name & Age; assign values to it
var person = new { Name = "Joe", Age = 30 };

//output the value of the Name property of the anonymous type: Joe
Console.WriteLine(person.Name);

//output the value of the Age property of the anonymous type: 30
Console.WriteLine(person.Age);

//Operator Overloading: Define / redefine the behaviour of operators for user defined types
//Syntax: public static returnType operator OperatorSymbol (parameter list){ methodbody}
//Create two instance of the Point class with specified values for X & Y
var point1 = new Point(1, 2);
var point2 = new Point(2, 3);

//Add the above 2 instances using the overlaoded + operator
var result = point1 + point2;
Console.WriteLine($"({result.X}, {result.Y})");

//Define a class: Point
public class Point 
{ 
    //create properties to hold X & Y co-ordinates
    public int X { get; set; }
    public int Y { get; set; }

    //create a constructor to initialize the X & Y co-ordinates
    public Point(int x, int y)
    { 
        X = x;
        Y = y;
    }

    //overload the + operator to add not values but instances of the Point class
    //Syntax: public static returnType operator OperatorSymbol (parameter list){ methodbody}
    public static Point operator +(Point a, Point b)
    { 
        //Return a new Point instance that is the sum of X & Y co-ordinates
        return new Point(a.X + b.X, a.Y + b.Y);
    }

}



