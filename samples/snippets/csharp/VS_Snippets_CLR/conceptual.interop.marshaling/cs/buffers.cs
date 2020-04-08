//<snippet1>
using System;
using System.Text;
using System.Runtime.InteropServices;

//<snippet2>
internal static class NativeMethods
{
    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    internal static extern int GetSystemDirectory(
        StringBuilder sysDirBuffer, int size);

    [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
    internal static extern IntPtr GetCommandLine();
}
//</snippet2>

//<snippet3>
public class App
{
    public static void Main()
    {
        // Call GetSystemDirectory.
        StringBuilder sysDirBuffer = new StringBuilder(256);
        NativeMethods.GetSystemDirectory(sysDirBuffer, sysDirBuffer.Capacity);
        // ...
        // Call GetCommandLine.
        IntPtr cmdLineStr = NativeMethods.GetCommandLine();
        string commandLine = Marshal.PtrToStringAuto(cmdLineStr);
    }
}
//</snippet3>
//</snippet1>
