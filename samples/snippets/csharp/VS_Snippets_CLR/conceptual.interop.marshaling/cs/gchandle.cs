//<snippet39>
using System;
using System.IO;
using System.Runtime.InteropServices;

//<snippet40>
public delegate bool CallBack(int handle, IntPtr param);

internal static class NativeMethods
{
    // Passes a managed object as an LPARAM type.
    // Declares a managed prototype for the unmanaged function.
    [DllImport("user32.dll")]
    internal static extern bool EnumWindows(CallBack cb, IntPtr param);
}
//</snippet40>

//<snippet41>
public class App
{
    public static void Main()
    {
        TextWriter tw = System.Console.Out;
        GCHandle gch = GCHandle.Alloc(tw);
        CallBack cewp = new CallBack(CaptureEnumWindowsProc);

        // Platform invoke prevents the delegate from being garbage
        // collected before the call ends.
        NativeMethods.EnumWindows(cewp, (IntPtr)gch);
        gch.Free();
    }

    private static bool CaptureEnumWindowsProc(int handle, IntPtr param)
    {
        GCHandle gch = (GCHandle)param;
        TextWriter tw = (TextWriter)gch.Target;
        tw.WriteLine(handle);
        return true;
    }
}
//</snippet41>
//</snippet39>
