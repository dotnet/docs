//<snippet1>
using System;
using System.Runtime.InteropServices;

class Program
{

    static void Run()
    {
        Console.WriteLine("Calling Marshal.GetITypeInfoForType...");

        // Get the ITypeInfo pointer for an Object type
        IntPtr pointer = Marshal.GetITypeInfoForType(typeof(object));

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