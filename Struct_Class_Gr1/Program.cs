using System;

class Program {
    static void Main(string[] args) 
    { 
        //Using the Class Person:
        //create 2 person objects
        //person1 initialize name & age
        Person person1 = new Person("Joe", 27);
        //person2 make reference to person1 instead of initializing name & age
        Person person2 = person1; //assigned person1 reference to person2 (reference copy)
        //display objects output
        person1.Display(); //Output: Name: Joe, Age: 27
        person2.Display(); //Output: Name: Joe, Age: 27

        //using person2 object, change the Name property (what happens?)
        person2.Name = "Bob"; //change the name property of person2 (and person1 because both are referencing the same object)

        //display the output by calling the Display name
        person1.Display(); //Output: Name: Bob, Age: 27
        person2.Display(); //Output: Name: Bob, Age: 27

        //Using the Point Struct
        //create 2 point objects
        //point1 initialize X & Y
        Point point1 = new Point(10, 20);
        Point point2 = point1; //assigned point1 to point2 (Value copy)
        //using point2 object, change the X property (what happens?)
        point2.X = 50; //Change the value of X only in point2 object; point1 object X property remains unchanged
        point2.Y = 100; //Change the value of Y only in point2 object; point1 object Y property remains unchanged
        //display output
        point1.Display();
        point2.Display();

    }


}

//class structure: Clas  to represent a person with name & age
//properties: Name & age
//constructor that initializes Name & age
//Display Method for name & age

public class Person
{
    //properties to get/set name & age
    public string Name { get; set; } 
    public int Age { get; set; }

    //Constructor to initiliaze the name & age
    public Person(string name, int age) 
        { 
            Name = name;
            Age = age;
        }

    //Method to display the name & age
    public void Display() 
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

//struct structure
public struct Point
{
    //properties to get/set the X & Y co-ordinates
    public int X { get; set; }
    public int Y { get; set; }

    //constructor to initialize the X & Y co-ordinates
    public Point(int x, int y) 
    { 
        X = x;
        Y = y;
    }


    //display method to show X & Y co-oridnates
    public void Display() {
        Console.WriteLine($"X: {X}, Y: {Y}");
    
    }

}