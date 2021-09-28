//<snippet45>
using System;
using System.Runtime.InteropServices;

//<snippet46>
internal class NativeMethods
{
    internal enum DataType
    {
        DT_I2 = 1,
        DT_I4,
        DT_R4,
        DT_R8,
        DT_STR
    }

    // Uses AsAny when void* is expected.
    [DllImport("..\\LIB\\PInvokeLib.dll")]
    internal static extern void SetData(DataType t,
        [MarshalAs(UnmanagedType.AsAny)] object o);

    // Uses overloading when void* is expected.
    [DllImport("..\\LIB\\PInvokeLib.dll", EntryPoint = "SetData")]
    internal static extern void SetData2(DataType t, ref double i);

    [DllImport("..\\LIB\\PInvokeLib.dll", EntryPoint = "SetData")]
    internal static extern void SetData2(DataType t, string s);
}
//</snippet46>

//<snippet47>
public class App
{
    public static void Main()
    {
        Console.WriteLine("Calling SetData using AsAny... \n");
        NativeMethods.SetData(NativeMethods.DataType.DT_I2, (short)12);
        NativeMethods.SetData(NativeMethods.DataType.DT_I4, (long)12);
        NativeMethods.SetData(NativeMethods.DataType.DT_R4, (float)12);
        NativeMethods.SetData(NativeMethods.DataType.DT_R8, (double)12);
        NativeMethods.SetData(NativeMethods.DataType.DT_STR, "abcd");

        Console.WriteLine("\nCalling SetData using overloading... \n");
        double d = 12;
        NativeMethods.SetData2(NativeMethods.DataType.DT_R8, ref d);
        NativeMethods.SetData2(NativeMethods.DataType.DT_STR, "abcd");
    }
}
//</snippet47>
//</snippet45>
