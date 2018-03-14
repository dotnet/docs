//<snippet1>
using System;
using System.Runtime.InteropServices;

class Program
{

    static void Run()
    {

        // Create an int object
        int obj = 1;

        Console.WriteLine("Calling Marshal.GetIUnknownForObjectInContext...");

        // Get the IUnKnown pointer for the Integer object
        IntPtr pointer = Marshal.GetIUnknownForObjectInContext(obj);

        Console.WriteLine("Calling Marshal.Release...");

        // Always call Marshal.Release to decrement the reference count.
        Marshal.Release(pointer);
    }

    static void Main(string[] args)
    {
        Run();
    }
}
//</snippet1>