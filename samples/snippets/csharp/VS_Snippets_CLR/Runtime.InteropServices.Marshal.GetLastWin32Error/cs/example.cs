//<snippet1>
using System;
using System.Runtime.InteropServices;

internal class Win32
{
    // Use DllImportAttribute to inport the Win32 MessageBox
    // function.  Set the SetLastError flag to true to allow
    // the function to set the Win32 error.
    [DllImportAttribute("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int MessageBox(IntPtr hwnd, String text, String caption, uint type);

}

class Program
{

    static void Run()
    {
        // Call the MessageBox with normal parameters.

        Console.WriteLine("Calling Win32 MessageBox without error...");

        Win32.MessageBox(new IntPtr(0), "Press OK...", "Press OK Dialog", 0);

        // Get the last error and display it.
        int error = Marshal.GetLastWin32Error();

        Console.WriteLine("The last Win32 Error was: " + error);

        // Call the MessageBox with an invalid window handle to
        // produce a Win32 error.

        Console.WriteLine("Calling Win32 MessageBox with error...");

        Win32.MessageBox(new IntPtr(123132), "Press OK...", "Press OK Dialog", 0);

        // Get the last error and display it.

        error = Marshal.GetLastWin32Error();

        Console.WriteLine("The last Win32 Error was: " + error);
    }

    static void Main(string[] args)
    {
        Run();
    }
}
// This code example displays the following to the console: 
//
// Calling Win32 MessageBox without error...
// The last Win32 Error was: 0
// Calling Win32 MessageBox with error...
// The last Win32 Error was: 1400
//</snippet1>