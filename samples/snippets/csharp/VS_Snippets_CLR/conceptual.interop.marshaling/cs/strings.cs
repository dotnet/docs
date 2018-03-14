//<snippet13>
using System;
using System.Text;
using System.Runtime.InteropServices;

//<snippet14>
// Declares a managed structure for each unmanaged structure.
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
public struct MyStrStruct
{
    public string buffer;
    public int size;
}

[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct MyStrStruct2
{
    public string buffer;
    public int size;
}

public class LibWrap
{
    // Declares managed prototypes for unmanaged functions.
    [DllImport("..\\LIB\\PinvokeLib.dll")]
    public static extern string TestStringAsResult();

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    public static extern void TestStringInStruct(ref MyStrStruct mss);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    public static extern void TestStringInStructAnsi(ref MyStrStruct2 mss);
}
//</snippet14>

//<snippet15>
public class App
{
    public static void Main()
    {
        // String as result.
        string str = LibWrap.TestStringAsResult();
        Console.WriteLine("\nString returned: {0}", str);

        // Initializes buffer and appends something to the end so the whole
        // buffer is passed to the unmanaged side.
        StringBuilder buffer = new StringBuilder("content", 100);
        buffer.Append((char)0);
        buffer.Append('*', buffer.Capacity - 8);

        MyStrStruct mss;
        mss.buffer = buffer.ToString();
        mss.size = mss.buffer.Length;

        LibWrap.TestStringInStruct(ref mss);
        Console.WriteLine( "\nBuffer after Unicode function call: {0}",
            mss.buffer );

        StringBuilder buffer2 = new StringBuilder("content", 100);
        buffer2.Append((char)0);
        buffer2.Append('*', buffer2.Capacity - 8);

        MyStrStruct2 mss2;
        mss2.buffer = buffer2.ToString();
        mss2.size = mss2.buffer.Length;

        LibWrap.TestStringInStructAnsi(ref mss2);
        Console.WriteLine("\nBuffer after Ansi function call: {0}",
            mss2.buffer);
    }
}
//</snippet15>
//</snippet13>
