// <Snippet1>
using System;

class Rectangle
{
   private Point a, b;

   public Rectangle(int upLeftX, int upLeftY, int downRightX, int downRightY)
   {
      this.a = new Point(upLeftX, upLeftY);
      this.b = new Point(downRightX, downRightY);
   }

   public override bool Equals(Object obj)
   {
      // Perform an equality check on two rectangles (Point object pairs).
      if (obj == null || GetType() != obj.GetType())
          return false;
      Rectangle r = (Rectangle)obj;
      return a.Equals(r.a) && b.Equals(r.b);
   }

   public override int GetHashCode()
   {
      return Tuple.Create(a, b).GetHashCode();
   }

    public override String ToString()
    {
       return String.Format("Rectangle({0}, {1}, {2}, {3})",
                            a.x, a.y, b.x, b.y);
    }
}

class Point
{
  internal int x;
  internal int y;

  public Point(int X, int Y)
  {
     this.x = X;
     this.y = Y;
  }

  public override bool Equals (Object obj)
  {
     // Performs an equality check on two points (integer pairs).
     if (obj == null || GetType() != obj.GetType()) return false;
     Point p = (Point)obj;
     return (x == p.x) && (y == p.y);
  }

  public override int GetHashCode()
  {
     return Tuple.Create(x, y).GetHashCode();
  }
}

class Example
{
   public static void Main()
   {
      Rectangle r1 = new Rectangle(0, 0, 100, 200);
      Rectangle r2 = new Rectangle(0, 0, 100, 200);
      Rectangle r3 = new Rectangle(0, 0, 150, 200);

      Console.WriteLine($"{r1} = {r2}: {r1.Equals(r2)}");
      Console.WriteLine($"{r1} = {r3}: {r1.Equals(r3)}");
      Console.WriteLine($"{r2} = {r3}: {r2.Equals(r3)}");
   }
}
// The example displays the following output:
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 100, 200): True
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
//    Rectangle(0, 0, 100, 200) = Rectangle(0, 0, 150, 200): False
// </Snippet1>
