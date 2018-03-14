//<snippet26>
using System;
using System.Runtime.InteropServices;

//<snippet28>
// Declares managed structures instead of unions.
[StructLayout(LayoutKind.Explicit)]
public struct MyUnion
{
    [FieldOffset(0)]
    public int i;
    [FieldOffset(0)]
    public double d;
}

[StructLayout(LayoutKind.Explicit, Size=128)]
public struct MyUnion2_1
{
    [FieldOffset(0)]
    public int i;
}

[StructLayout(LayoutKind.Sequential)]
public struct MyUnion2_2
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
    public string str;
}

public class LibWrap
{
    // Declares managed prototypes for unmanaged function.
    [DllImport( "..\\LIB\\PInvokeLib.dll")]
    public static extern void TestUnion(MyUnion u, int type);

    [DllImport( "..\\LIB\\PInvokeLib.dll")]
    public static extern void TestUnion2(MyUnion2_1 u, int type);

    [DllImport( "..\\LIB\\PInvokeLib.dll")]
    public static extern void TestUnion2(MyUnion2_2 u, int type);
}
//</snippet28>

//<snippet29>
public class App
{
    public static void Main()
    {
        MyUnion mu = new MyUnion();
        mu.i = 99;
        LibWrap.TestUnion(mu, 1);

        mu.d = 99.99;
        LibWrap.TestUnion(mu, 2);

        MyUnion2_1 mu2_1 = new MyUnion2_1();
        mu2_1.i = 99;
        LibWrap.TestUnion2(mu2_1, 1);

        MyUnion2_2 mu2_2 = new MyUnion2_2();
        mu2_2.str = "*** string ***";
        LibWrap.TestUnion2(mu2_2, 2);
    }
}
//</snippet29>
//</snippet26>
