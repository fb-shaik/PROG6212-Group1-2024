using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU1_Shape_App_Dynamic_Anon_OperatorOverloading_Gr1
{
    //define the Shape class as abstract
     public abstract class Shape
    {
        //define a property to hold the name of the shape
        public string Name { get; set; }

        //abstract method to calculate the area of the shape
        public abstract double GetArea();
    }

    //define Circle & Rectangle child class that inherits from the base: Shape class

    public class Circle : Shape 
    
    { 
        //property to hold radius of the circle
        public double Radius { get; set; }

        //Constructor to initialize the radius & set the name to "Cirle
        public Circle(double radius) 
        {
            Name = "Circle";
            Radius = radius;
        }
        //Override the GetArea Method
        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        //operator overloading: Add the area of two circles & return a new Circle with the equivalent area
        public static Circle operator +(Circle a, Circle b) 
        {
            //calculate the new radius from the sum of the areas of the 2 circles
            return new Circle(Math.Sqrt((a.GetArea() + b.GetArea()) / Math.PI));
        }

    }

    //create a second child class: Rectangle
    public class Rectangle : Shape {
        
    
    }
    // define the properties to hold width & height
    // define constructor to initialize width, height, set Name to 'Rectangle'
   //override the getArea method 
   //operator overloading: Add two rectangle objects & return new Rectangle with the sum of width & height of the 2 objects




}
