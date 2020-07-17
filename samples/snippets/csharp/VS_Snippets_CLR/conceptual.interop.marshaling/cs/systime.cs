//<snippet25>
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class SystemTime
{
    public ushort year;
    public ushort month;
    public ushort weekday;
    public ushort day;
    public ushort hour;
    public ushort minute;
    public ushort second;
    public ushort millisecond;
}

internal static class NativeMethods
{
    // Declares a managed prototype for the unmanaged function using Platform Invoke.
    [DllImport("Kernel32.dll")]
    internal static extern void GetSystemTime([In, Out] SystemTime st);
}

public class App
{
    public static void Main()
    {
        Console.WriteLine("C# SysTime Sample using Platform Invoke");
        SystemTime st = new SystemTime();
        NativeMethods.GetSystemTime(st);
        Console.Write("The Date is: ");
        Console.Write($"{st.month} {st.day} {st.year}");
    }
}

// The program produces output similar to the following:
//
// C# SysTime Sample using Platform Invoke
// The Date is: 3 21 2010
//</snippet25>
