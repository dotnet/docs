//<SNIPPET1>
using System;
using System.Runtime.InteropServices;

public struct Point
{
    public int x;
    public int y;
}

class Example
{

    static void Main()
    {

        // Create a point struct.
        Point p;
        p.x = 1;
        p.y = 1;

        Console.WriteLine("The value of first point is " + p.x + " and " + p.y + ".");

        // Initialize unmanged memory to hold the struct.
        IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(p));

        try
        {

            // Copy the struct to unmanaged memory.
            Marshal.StructureToPtr(p, pnt, false);

            // Create another point.
            Point anotherP;

            // Set this Point to the value of the 
            // Point in unmanaged memory. 
            anotherP = (Point)Marshal.PtrToStructure(pnt, typeof(Point));

            Console.WriteLine("The value of new point is " + anotherP.x + " and " + anotherP.y + ".");

        }
        finally
        {
            // Free the unmanaged memory.
            Marshal.FreeHGlobal(pnt);
        }
        


    }

}
//</SNIPPET1>