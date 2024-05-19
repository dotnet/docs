// <Snippet5>
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
        return ShiftAndWrap(x.GetHashCode(), 2) ^ y.GetHashCode();
    }

    private int ShiftAndWrap(int value, int positions)
    {
        positions = positions & 0x1F;

        // Save the existing bit pattern, but interpret it as an unsigned integer.
        uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        // Preserve the bits to be discarded.
        uint wrapped = number >> (32 - positions);
        // Shift and wrap the discarded bits.
        return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
    }
}

public class Example2
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
//       28
//       37
// </Snippet5>

public class Utility
{
   // <Snippet4>
    public int ShiftAndWrap(int value, int positions)
    {
        positions = positions & 0x1F;

        // Save the existing bit pattern, but interpret it as an unsigned integer.
        uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
        // Preserve the bits to be discarded.
        uint wrapped = number >> (32 - positions);
        // Shift and wrap the discarded bits.
        return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
    }
   // </Snippet4>
}
