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
                         sh, new Square(0) };
      foreach (var shape in shapes)
         ShowShapeInfo(shape);
   }

   private static void ShowShapeInfo(Shape sh)
   {
      switch (sh)
      {
         case Shape shape when shape == null:
            Console.WriteLine($"An uninitialized shape");
            break;
         case Shape shape when sh.Area == 0:
            Console.WriteLine($"The shape: {sh.GetType().Name} with no dimensions");
            break;
         case Rectangle r when sh.Area > 0:
            Console.WriteLine("Information about rectangle:");
            Console.WriteLine($"   Dimensions: {r.Length} x {r.Width}");
            Console.WriteLine($"   Area: {r.Area}");
            break;
         case Square sq when sh.Area > 0:
            Console.WriteLine("Information about square:");
            Console.WriteLine($"   Length of a side: {sq.Side}");
            Console.WriteLine($"   Area: {sq.Area}");
            break;
         case Shape shape when sh != null:
            Console.WriteLine("A {sh.GetType().Name} shape");
            break;
         default:
            Console.WriteLine($"The {nameof(sh)} variable does not represent a Shape.");
            break;   
      }
   }
}
// The example displays the following output:
//     Information about rectangle:
//        Dimensions: 10 x 10
//        Area: 100
//     Information about rectangle:
//        Dimensions: 5 x 7
//        Area: 35
//     The sh variable does not represent a Shape.
//     The shape: Square with no dimensions
// </Snippet1>
