//<snippet1>
using System;
using System.Text;
using System.Runtime.InteropServices;

//<snippet2>
public class LibWrap
{
    [DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
    public static extern int GetSystemDirectory(StringBuilder
        sysDirBuffer, int size);

    [DllImport("Kernel32.dll", CharSet=CharSet.Auto)]
    public static extern IntPtr GetCommandLine();
}
//</snippet2>

//<snippet3>
public class App
{
    public static void Main()
    {
        // Call GetSystemDirectory.
        StringBuilder sysDirBuffer = new StringBuilder(256);
        LibWrap.GetSystemDirectory(sysDirBuffer, sysDirBuffer.Capacity);
        // ...
        // Call GetCommandLine.
        IntPtr cmdLineStr = LibWrap.GetCommandLine();
        string commandLine = Marshal.PtrToStringAuto(cmdLineStr);
    }
}
//</snippet3>
//</snippet1>
