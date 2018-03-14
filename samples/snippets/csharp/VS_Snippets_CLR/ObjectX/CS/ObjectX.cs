//Types:System.Object Vendor: Richter
//<snippet1>
using System;

// The Point class is derived from System.Object.
class Point 
{
    public int x, y;

    public Point(int x, int y) 
    {
        this.x = x;
        this.y = y;
    }
    
    //<snippet2>
    public override bool Equals(object obj) 
    {
        // If this and obj do not refer to the same type, then they are not equal.
        if (obj.GetType() != this.GetType()) return false;

        // Return true if  x and y fields match.
        Point other = (Point) obj;
        return (this.x == other.x) && (this.y == other.y);
    }
    //</snippet2>

    //<snippet3>
    // Return the XOR of the x and y fields.
    public override int GetHashCode() 
    {
        return x ^ y;
    }
    //</snippet3>

    //<snippet4>
    // Return the point's value as a string.
    public override String ToString() 
    {
        return String.Format("({0}, {1})", x, y);
    }
    //</snippet4>

    //<snippet5>
    // Return a copy of this point object by making a simple field copy.
    public Point Copy() 
    {
        return (Point) this.MemberwiseClone();
    }
    //</snippet5>
}

public sealed class App {
    static void Main() 
    {
        // Construct a Point object.
        Point p1 = new Point(1,2);

        // Make another Point object that is a copy of the first.
        Point p2 = p1.Copy();

        // Make another variable that references the first Point object.
        Point p3 = p1;

	//<snippet6>
        // The line below displays false because p1 and p2 refer to two different objects.
        Console.WriteLine(Object.ReferenceEquals(p1, p2));
        //</snippet6>

        //<snippet7>
        // The line below displays true because p1 and p2 refer to two different objects that have the same value.
        Console.WriteLine(Object.Equals(p1, p2));
        //</snippet7>
      
        // The line below displays true because p1 and p3 refer to one object.
        Console.WriteLine(Object.ReferenceEquals(p1, p3));
        
        //<snippet8> 
        // The line below displays: p1's value is: (1, 2)
        Console.WriteLine("p1's value is: {0}", p1.ToString());
        //</snippet8>
    }
}

// This code example produces the following output:
//
// False
// True
// True
// p1's value is: (1, 2)
//
//</snippet1>
