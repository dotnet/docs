// <Snippet1>
using System;

public abstract class Shape
{
   public abstract double Area { get; }
   public abstract double Circumference { get; } 
}

public class Rectangle : Shape
{
   public Rectangle(double length, double width) 
   {
      Length = length;
      Width = width; 
   }

   public double Length { get; set; }
   public double Width { get; set; }
   
   public override double Area
   { 
      get { return Math.Round(Length * Width,2); } 
   } 
   
   public override double Circumference 
   {
      get { return (Length + Width) * 2; }
   }
}

public class Square : Rectangle
{
   public Square(double side) : base(side, side) 
   {
      Side = side; 
   }

   public double Side { get; set; }
}

public class Example
{
   public static void Main()
   {
      Shape sh = null;
      Shape[] shapes = { new Square(10), new Rectangle(5, 7),
                         new Rectangle(10, 10), sh, new Square(0) };
      foreach (var shape in shapes)
         ShowShapeInfo(shape);
   }

   private static void ShowShapeInfo(Object obj)
   {
      switch (obj)
      {
         case Shape shape when shape.Area == 0:
            Console.WriteLine($"The shape: {shape.GetType().Name} with no dimensions");
            break;
         case Rectangle r when r.Area > 0:
            Console.WriteLine("Information about the rectangle:");
            Console.WriteLine($"   Dimensions: {r.Length} x {r.Width}");
            Console.WriteLine($"   Area: {r.Area}");
            break;
         case Square sq when sq.Area > 0:
            Console.WriteLine("Information about the square:");
            Console.WriteLine($"   Length of a side: {sq.Side}");
            Console.WriteLine($"   Area: {sq.Area}");
            break;
         case Shape shape:
            Console.WriteLine($"A {shape.GetType().Name} shape");
            break;
         case null:
            Console.WriteLine($"The {nameof(obj)} variable is uninitialized.");
            break;
         default:
            Console.WriteLine($"The {nameof(obj)} variable does not represent a Shape.");
            break;   
      }
   }
}
// The example displays the following output:
//       Information about the rectangle:
//          Dimensions: 10 x 10
//          Area: 100
//       Information about the rectangle:
//          Dimensions: 5 x 7
//          Area: 35
//       Information about the rectangle:
//          Dimensions: 10 x 10
//          Area: 100
//       The obj variable is uninitialized.
//       The shape: Square with no dimensions
// </Snippet1>
