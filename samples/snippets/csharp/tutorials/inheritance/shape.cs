// <Snippet1>
using System;

public abstract class Shape
{
   public abstract double Area { get; }
   
   public abstract double Perimeter { get; }
 
   public override string ToString()
   {
      return GetType().Name;
   }
   public static double GetArea(Shape shape)
   {
      return shape.Area;
   }

   public static double GetPerimeter(Shape shape)
   {
      return shape.Perimeter;
   }
}
// </Snippet1>

namespace DerivedClasses
{
// <Snippet2>
using System;

public class Square : Shape
{
   double length; 
   
   public Square(double length)
   {
      this.length = length;
   }

   public double Side
   { 
      get { return length; }
   }

   public override double Area
   {
      get { return Math.Pow(length, 2); }
   }

   public override double Perimeter
   {
      get { return length * 4; }
   }

   public double Diagonal
   { 
      get { return Math.Round(Math.Sqrt(2) * length, 2) ; }
   }
}

public class Rectangle : Shape
{
   double _length;
   double _width;

   public Rectangle(double length, double width)
   {
      _length = length;
      _width = width;
   }

   public override double Area
   {
      get { return _length * _width; }
   }

   public override double Perimeter
   { 
      get { return 2 * _length + 2 * _width; } 
   }

   public bool IsSquare()
   {
      return _length == _width;
   }

   public double Diagonal
   { 
      get { return Math.Round(Math.Sqrt(Math.Pow(_length, 2) + Math.Pow(_width, 2)), 2); }
   }
}

public class Circle : Shape
{
   double rad;

   public Circle(double radius)
   {
      rad = radius;
   } 

   public override double Area
   {
      get { return Math.Round(Math.Pow(Math.PI * rad, 2), 2); }
   }

   public override double Perimeter
   { 
      get { return Math.Round(Math.PI * 2 * rad, 2); }
   }

   // Define a circumference, since it's the more familiar term.
   public double Circumference
   {
      get { return Perimeter; }
   }

   public double Radius
   {
      get { return rad; }
   }

   public double Diameter
   {
      get { return rad * 2; }
   }
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
         Console.WriteLine("{0}: area, {1}; perimeter, {2}",
                           shape, Shape.GetArea(shape), 
                           Shape.GetPerimeter(shape));
         var rect = shape as Rectangle;
         if (rect != null) {
            Console.WriteLine("   Square: {0}, Diagonal: {1}", 
                              rect.IsSquare(), rect.Diagonal);
            continue;
         }
         var sq = shape as Square;
         if (sq != null) {
            Console.WriteLine("   Diagonal: {0}", sq.Diagonal);
            continue;
         }
      }   
   }
}
// The example displays the following output:
//         Rectangle: area, 120; perimeter, 44
//            Square: False, Diagonal: 15.62
//         Square: area, 25; perimeter, 20
//            Diagonal: 7.07
//         Circle: area, 88.83; perimeter, 18.85
// </Snippet3>
} // Namespace definition.