//<snippet36>
using System;
using System.Runtime.InteropServices;

//<snippet37>
public delegate bool FPtr(int value);
public delegate bool FPtr2(string value);

public class LibWrap
{
    // Declares managed prototypes for unmanaged functions.
    [DllImport("..\\LIB\\PinvokeLib.dll")]
    public static extern void TestCallBack(FPtr cb, int value);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    public static extern void TestCallBack2(FPtr2 cb2, String value);
}
//</snippet37>

//<snippet38>
public class App
{
    public static void Main()
    {
        FPtr cb = new FPtr(App.DoSomething);
        LibWrap.TestCallBack(cb, 99);
        FPtr2 cb2 = new FPtr2(App.DoSomething2);
        LibWrap.TestCallBack2(cb2, "abc");
    }

    public static bool DoSomething(int value)
    {
        Console.WriteLine("\nCallback called with param: {0}", value);
        // ...
        return true;
    }

    public static bool DoSomething2( String value )
    {
        Console.WriteLine("\nCallback called with param: {0}", value);
        // ...
        return true;
    }
}
//</snippet38>
//</snippet36>
