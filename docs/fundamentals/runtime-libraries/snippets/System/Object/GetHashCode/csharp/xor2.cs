// <Snippet3>
using System;

public struct Point3
{
    private int x;
    private int y;

    public Point3(int x, int y)
    {
       this.x = x;
       this.y = y;
    }

    public override bool Equals(Object obj)
    {
        if (obj is Point3)
        {
            Point3 p = (Point3) obj;
            return x == p.x & y == p.y;
        }
        else
        {
            return false;
        }      
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
        Point3 pt = new Point3(5, 8);
        Console.WriteLine(pt.GetHashCode());

        pt = new Point3(8, 5);
        Console.WriteLine(pt.GetHashCode());
   }
}
// The example displays the following output:
//       173
//       269
// </Snippet3>
