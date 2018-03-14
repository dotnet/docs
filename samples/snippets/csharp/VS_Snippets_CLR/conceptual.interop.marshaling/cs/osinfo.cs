//<snippet10>
using System;
using System.Runtime.InteropServices;

//<snippet11>
[StructLayout(LayoutKind.Sequential)]
public class OSVersionInfo
{
    public int OSVersionInfoSize;
    public int MajorVersion;
    public int MinorVersion;
    public int BuildNumber;
    public int PlatformId;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
    public String CSDVersion;
}

[StructLayout(LayoutKind.Sequential)]
public struct OSVersionInfo2
{
    public int OSVersionInfoSize;
    public int MajorVersion;
    public int MinorVersion;
    public int BuildNumber;
    public int PlatformId;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
    public String CSDVersion;
}

public class LibWrap
{
    [DllImport("kernel32")]
    public static extern bool GetVersionEx([In, Out] OSVersionInfo osvi);

    [DllImport("kernel32", EntryPoint="GetVersionEx")]
    public static extern bool GetVersionEx2(ref OSVersionInfo2 osvi);
}
//</snippet11>

//<snippet12>
public class App
{
    public static void Main()
    {
        Console.WriteLine("\nPassing OSVersionInfo as a class");

        OSVersionInfo osvi = new OSVersionInfo();
        osvi.OSVersionInfoSize = Marshal.SizeOf(osvi);

        LibWrap.GetVersionEx(osvi);

        Console.WriteLine("Class size:    {0}", osvi.OSVersionInfoSize);
        Console.WriteLine("OS Version:    {0}.{1}", osvi.MajorVersion, osvi.MinorVersion);

        Console.WriteLine("\nPassing OSVersionInfo as a struct" );

        OSVersionInfo2 osvi2 = new OSVersionInfo2();
        osvi2.OSVersionInfoSize = Marshal.SizeOf(osvi2);

        LibWrap.GetVersionEx2(ref osvi2);
        Console.WriteLine("Struct size:   {0}", osvi2.OSVersionInfoSize);
        Console.WriteLine("OS Version:    {0}.{1}", osvi2.MajorVersion, osvi2.MinorVersion);
    }
}
//</snippet12>
//</snippet10>
