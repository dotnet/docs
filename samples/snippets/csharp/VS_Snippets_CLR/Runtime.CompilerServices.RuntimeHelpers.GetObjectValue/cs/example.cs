//<snippet1>
using System;
using System.Runtime.CompilerServices;

// Declare a value type.
struct Point2I
{
    public int x;
    public int y;
}

class Program
{

    static void Main(string[] args)
    {
        // Allocate an unboxed Point2I (not on the heap).
        Point2I pnt;
        pnt.x = 0;
        pnt.y = 0;

        // Box the value.  (Put it in the heap.)
        object objPntr = RuntimeHelpers.GetObjectValue(pnt);

    }
}
//</snippet1>