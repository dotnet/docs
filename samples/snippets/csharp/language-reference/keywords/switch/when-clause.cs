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

public class Circle : Shape
{
   public Circle(double radius) 
   {
      Radius = radius;
   } 
   
   public double Radius { get; set; }

   public override double Circumference
   {
      get { return 2 * Math.PI * Radius; }
   }

   public override double Area
   {
      get { return Math.PI * Math.Pow(Radius, 2); } 
   }
}

public class Example
{
   public static void Main()
   {
      Shape sh = null;
      Shape[] shapes = { new Square(10), new Rectangle(5, 7),
                         sh, new Square(0), new Rectangle(8, 8),
                         new Circle(3) };
      foreach (var shape in shapes)
         ShowShapeInfo(shape);
   }

   private static void ShowShapeInfo(Shape sh)
   {
      switch (sh)
      {
         // Note that this code never evaluates to true.
         case Shape shape when shape == null:
            Console.WriteLine($"An uninitialized shape (shape == null)");
            break;
         case null:
            Console.WriteLine($"An uninitialized shape");
            break;
         case Shape shape when sh.Area == 0:
            Console.WriteLine($"The shape: {sh.GetType().Name} with no dimensions");
            break;
         case Square sq when sh.Area > 0:
            Console.WriteLine("Information about square:");
            Console.WriteLine($"   Length of a side: {sq.Side}");
            Console.WriteLine($"   Area: {sq.Area}");
            break;
         case Rectangle r when r.Length == r.Width && r.Area > 0:
            Console.WriteLine("Information about square rectangle:");
            Console.WriteLine($"   Length of a side: {r.Length}");
            Console.WriteLine($"   Area: {r.Area}");
            break;
         case Rectangle r when sh.Area > 0:
            Console.WriteLine("Information about rectangle:");
            Console.WriteLine($"   Dimensions: {r.Length} x {r.Width}");
            Console.WriteLine($"   Area: {r.Area}");
            break;
         case Shape shape when sh != null:
            Console.WriteLine($"A {sh.GetType().Name} shape");
            break;
         default:
            Console.WriteLine($"The {nameof(sh)} variable does not represent a Shape.");
            break;   
      }
   }
}
// The example displays the following output:
//       Information about square:
//          Length of a side: 10
//          Area: 100
//       Information about rectangle:
//          Dimensions: 5 x 7
//          Area: 35
//       An uninitialized shape
//       The shape: Square with no dimensions
//       Information about square rectangle:
//          Length of a side: 8
//          Area: 64
//       A Circle shape
// </Snippet1>
