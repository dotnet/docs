// <Snippet3>
using System;

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
       if (!(obj is Point)) return false;
       
       Point p = (Point) obj;
       return x == p.x & y == p.y;
    }
    
    public override int GetHashCode()
    { 
        return Tuple.Create(x, y).GetHashCode();
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
//       173
//       269
// </Snippet3>
