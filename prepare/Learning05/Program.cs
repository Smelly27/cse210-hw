using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store different shapes
        List<Shape> shapes = new List<Shape>();

        // Create a square, rectangle, and circle
        Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 6, 4);
        Circle circle = new Circle("Green", 3);

        // Add each shape to the list
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        // Loop through the shapes and display their information
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea():F2}");
            Console.WriteLine();
        }
    }
}