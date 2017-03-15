// <Snippet1>
using System;

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
      get { return 2 * Radius * Math.PI; }      
   }

   public double Circumference
   {
      get { return Math.PI * Math.Pow(Radius, 2); }
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

