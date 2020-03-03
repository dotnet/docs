//<snippet36>
using System;
using System.Runtime.InteropServices;

//<snippet37>
public delegate bool FPtr(int value);
public delegate bool FPtr2(string value);

internal static class NativeMethods
{
    // Declares managed prototypes for unmanaged functions.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void TestCallBack(FPtr cb, int value);

    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void TestCallBack2(FPtr2 cb2, string value);
}
//</snippet37>

//<snippet38>
public class App
{
    public static void Main()
    {
        FPtr cb = new FPtr(App.DoSomething);
        NativeMethods.TestCallBack(cb, 99);
        FPtr2 cb2 = new FPtr2(App.DoSomething2);
        NativeMethods.TestCallBack2(cb2, "abc");
    }

    public static bool DoSomething(int value)
    {
        Console.WriteLine($"\nCallback called with param: {value}");
        // ...
        return true;
    }

    public static bool DoSomething2(string value)
    {
        Console.WriteLine($"\nCallback called with param: {value}");
        // ...
        return true;
    }
}
//</snippet38>
//</snippet36>
