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
        return HashCode.Combine(x, y);
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
// The example displays output similar to the following.
// Note: HashCode.Combine results are not stable across .NET versions.
//       185727722
//       -363254492
// </Snippet3>
