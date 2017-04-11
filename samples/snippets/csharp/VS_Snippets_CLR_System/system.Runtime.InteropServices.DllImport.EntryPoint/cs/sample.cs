//<SNIPPET1>
using System;
using System.Runtime.InteropServices;

class Example
{
    // Use DllImport to import the Win32 MessageBox function.
    // Specify the method to import using the EntryPoint field and 
    // then change the name to MyNewMessageBoxMethod.
    [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MessageBox")]
    public static extern int MyNewMessageBoxMethod(IntPtr hWnd, String text, String caption, uint type);
    
    static void Main()
    {
        // Call the MessageBox function using platform invoke.
        MyNewMessageBoxMethod(new IntPtr(0), "Hello World!", "Hello Dialog", 0);
    }
}
//</SNIPPET1>