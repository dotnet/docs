// <Snippet2>
using System;

// A type that represents a 2-D point.
public struct Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
       this.x = x;
       this.y = y;
    }
    
    public override bool Equals(Object obj)
    {
       if (! (obj is Point)) return false;
       
       Point p = (Point) obj;
       return x == p.x & y == p.y;
    }
    
    public override int GetHashCode()
    { 
        return x ^ y;
    } 
} 

public class Example
{
   public static void Main()
   {
      Point pt = new Point(5, 8);
      Console.WriteLine(pt.GetHashCode());
        
      pt = new Point(8, 5);
      Console.WriteLine(pt.GetHashCode());
   }
}
// The example displays the following output:
//       13
//       13
// </Snippet2>
