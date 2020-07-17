//<snippet42>
using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

//<snippet43>
// Declares a managed structure for the unmanaged structure.
[StructLayout(LayoutKind.Sequential)]
public struct Overlapped
{
    // ...
}

// Declares a managed class for the unmanaged structure.
[StructLayout(LayoutKind.Sequential)]
public class Overlapped2
{
    // ...
}

internal static class NativeMethods
{
    // Declares managed prototypes for unmanaged functions.
    // Because Overlapped is a structure, you cannot pass null as a
    // parameter. Instead, declares an overloaded method.
    [DllImport("Kernel32.dll")]
    internal static extern bool ReadFile(
        HandleRef hndRef,
        StringBuilder buffer,
        int numberOfBytesToRead,
        out int numberOfBytesRead,
        ref Overlapped flag);

    [DllImport("Kernel32.dll")]
    internal static extern bool ReadFile(
        HandleRef hndRef,
        StringBuilder buffer,
        int numberOfBytesToRead,
        out int numberOfBytesRead,
        IntPtr flag); // Declares an int instead of a structure reference.

    // Because Overlapped2 is a class, you can pass null as parameter.
    // No overloading is needed.
    [DllImport("Kernel32.dll", EntryPoint = "ReadFile")]
    internal static extern bool ReadFile2(
        HandleRef hndRef,
        StringBuilder buffer,
        int numberOfBytesToRead,
        out int numberOfBytesRead,
        Overlapped2 flag);
}
//</snippet43>

//<snippet44>
public class App
{
    public static void Main()
    {
        FileStream fs = new FileStream("HandleRef.txt", FileMode.Open);
        // Wraps the FileStream handle in HandleRef to prevent it
        // from being garbage collected before the call ends.
        HandleRef hr = new HandleRef(fs, fs.SafeFileHandle.DangerousGetHandle());
        StringBuilder buffer = new StringBuilder(5);
        int read = 0;
        // Platform invoke holds a reference to HandleRef until the call
        // ends.
        NativeMethods.ReadFile(hr, buffer, 5, out read, IntPtr.Zero);
        Console.WriteLine($"Read {read} bytes with struct parameter: {buffer}");
        NativeMethods.ReadFile2(hr, buffer, 5, out read, null);
        Console.WriteLine($"Read {read} bytes with class parameter: {buffer}");
    }
}
//</snippet44>
//</snippet42>
