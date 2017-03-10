// <Snippet1>
using System;
using static System.Math;

public class Circle
{
   public Circle(double radius)
   {
      Radius = radius;
   }

   public double Radius { get; set; }

   public double Diameter
   {
      get { return 2 * Radius; }
   }

   public double Area
   {
      get { return 2 * Radius * PI; }      
   }

   public double Circumference
   {
      get { return PI * Pow(Radius, 2); }
   }
}
// </Snippet1>


class Program
{
   static void Main()
   {
      Console.WriteLine("Hello World!");
   }
}

