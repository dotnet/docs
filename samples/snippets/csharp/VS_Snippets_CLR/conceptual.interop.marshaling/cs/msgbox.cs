//<snippet4>
using System;
using System.Runtime.InteropServices;

//<snippet5>
public class LibWrap
{
    // Declares managed prototypes for unmanaged functions.
    [DllImport( "User32.dll", EntryPoint="MessageBox",
        CharSet=CharSet.Auto)]
    public static extern int MsgBox(int hWnd, string text, string caption,
      uint type);

    // Causes incorrect output in the message window.
    [DllImport( "User32.dll", EntryPoint="MessageBoxW",
        CharSet=CharSet.Ansi )]
    public static extern int MsgBox2(int hWnd, string text,
       string caption, uint type);

    // Causes an exception to be thrown. EntryPoint, CharSet, and
    // ExactSpelling fields are mismatched.
    [DllImport( "User32.dll", EntryPoint="MessageBox",
        CharSet=CharSet.Ansi, ExactSpelling=true )]
    public static extern int MsgBox3(int hWnd, string text,
        string caption, uint type);
}
//</snippet5>

//<snippet6>
public class MsgBoxSample
{
    public static void Main()
    {
        LibWrap.MsgBox(0, "Correct text", "MsgBox Sample", 0);
        LibWrap.MsgBox2(0, "Incorrect text", "MsgBox Sample", 0);

        try
        {
            LibWrap.MsgBox3(0, "No such function", "MsgBox Sample", 0);
        }
        catch(EntryPointNotFoundException)
        {
           Console.WriteLine("EntryPointNotFoundException thrown as expected!");
        }
    }
}
//</snippet6>
//</snippet4>
