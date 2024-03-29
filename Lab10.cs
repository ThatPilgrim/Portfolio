﻿// Code File Lab10.cs
using System;
public static class CircleDemo
{
    public static void Main()
    {
        double inpRadius;
        // create a circle object with no arg constructor
        Circle cir1 = new Circle();
        // create a circle object with one arg constructor
        Circle cir2 = new Circle(10);
         Circle cir3;

        // print out the area of the circles
        Console.WriteLine("Circle 1 has radius {0}, area {1:F2} and circumference {2:F2}",
         cir1.Radius, cir1.GetArea(), cir1.GetCircumference());
        Console.WriteLine("Circle 2 has radius {0}, area {1:F2} and circumference {2:F2}",
        cir2.Radius, cir2.GetArea(), cir2.GetCircumference());

        //prompt the user for a radius
        do
        {
            Console.Write("Enter a positive radius => ");
            inpRadius = Convert.ToDouble(Console.ReadLine());
        } while (inpRadius < 0);
        cir1.Radius = inpRadius;

        // print out the area of the circles
        Console.WriteLine("Circle 1 has radius {0} and area {1:F2}",
         cir1.Radius, cir1.GetArea());
        cir1.Radius = -8;
        // print out the area of the circles
        Console.WriteLine("Circle 1 has radius {0}, area {1:F2} and circumference {2:F2}", cir1.Radius,
        cir1.GetArea(), cir1.GetCircumference());
        Console.WriteLine("Circle 2 has radius {0}, area {1:F2} and circumference {2:F2}", cir2.Radius,
        cir2.GetArea(), cir2.GetCircumference());
        cir3 = cir2 + cir1;
        Console.WriteLine("Circle 2 has radius {0}, area {1:F2} and circumference {2:F2}", cir3.Radius,
        cir3.GetArea(), cir3.GetCircumference());
        Console.WriteLine("Circle 2 has radius {0} and area {1:F2}",
        cir2.Radius, cir2.GetArea());

        Console.ReadLine();
    }
}