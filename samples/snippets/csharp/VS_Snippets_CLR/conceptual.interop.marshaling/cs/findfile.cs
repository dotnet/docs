//<snippet16>
using System;
using System.Runtime.InteropServices;

//<snippet17>
// Declares a class member for each structure element.
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public class FindData
{
    public int fileAttributes = 0;
    // creationTime was an embedded FILETIME structure.
    public int creationTime_lowDateTime = 0;
    public int creationTime_highDateTime = 0;
    // lastAccessTime was an embedded FILETIME structure.
    public int lastAccessTime_lowDateTime = 0;
    public int lastAccessTime_highDateTime = 0;
    // lastWriteTime was an embedded FILETIME structure.
    public int lastWriteTime_lowDateTime = 0;
    public int lastWriteTime_highDateTime = 0;
    public int nFileSizeHigh = 0;
    public int nFileSizeLow = 0;
    public int dwReserved0 = 0;
    public int dwReserved1 = 0;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string fileName = null;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
    public string alternateFileName = null;
}

internal static class NativeMethods
{
    // Declares a managed prototype for the unmanaged function.
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr FindFirstFile(
        string fileName, [In, Out] FindData findFileData);
}
//</snippet17>

//<snippet18>
public class App
{
    public static void Main()
    {
        FindData fd = new FindData();
        IntPtr handle = NativeMethods.FindFirstFile("C:\\*.*", fd);
        Console.WriteLine($"The first file: {fd.fileName}");
    }
}
//</snippet18>
//</snippet16>
