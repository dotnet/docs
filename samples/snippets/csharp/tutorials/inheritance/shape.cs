// <Snippet1>
using System;

public abstract class Shape
{
   public abstract double Area { get; }

   public abstract double Perimeter { get; }

   public override string ToString() => GetType().Name;

   public static double GetArea(Shape shape) => shape.Area;

   public static double GetPerimeter(Shape shape) => shape.Perimeter;
}
// </Snippet1>

namespace DerivedClasses
{
// <Snippet2>
using System;

public class Square : Shape
{
   public Square(double length)
   {
      Side = length;
   }

   public double Side { get; }

   public override double Area => Math.Pow(Side, 2);

   public override double Perimeter => Side * 4;

   public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
}

public class Rectangle : Shape
{
   public Rectangle(double length, double width)
   {
      Length = length;
      Width = width;
   }

   public double Length { get; }

   public double Width { get; }

   public override double Area => Length * Width;

   public override double Perimeter => 2 * Length + 2 * Width;

   public bool IsSquare() => Length == Width;

   public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
}

public class Circle : Shape
{
   public Circle(double radius)
   {
      Radius = radius;
   }

   public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);

   public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);

   // Define a circumference, since it's the more familiar term.
   public double Circumference => Perimeter;

   public double Radius { get; }

   public double Diameter => Radius * 2;
}
// </Snippet2>
} // Namespace definition

namespace Example
{

using DerivedClasses;
// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      Shape[] shapes = { new Rectangle(10, 12), new Square(5),
                        new Circle(3) };
      foreach (var shape in shapes) {
         Console.WriteLine($"{shape}: area, {Shape.GetArea(shape)}; " +
                           $"perimeter, {Shape.GetPerimeter(shape)}");
         var rect = shape as Rectangle;
         if (rect != null) {
            Console.WriteLine($"   Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
            continue;
         }
         var sq = shape as Square;
         if (sq != null) {
            Console.WriteLine($"   Diagonal: {sq.Diagonal}");
            continue;
         }
      }
   }
}
// The example displays the following output:
//         Rectangle: area, 120; perimeter, 44
//            Is Square: False, Diagonal: 15.62
//         Square: area, 25; perimeter, 20
//            Diagonal: 7.07
//         Circle: area, 28.27; perimeter, 18.85
// </Snippet3>
} // Namespace definition.
