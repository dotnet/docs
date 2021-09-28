//<snippet4>
using System;
using System.Runtime.InteropServices;

//<snippet5>
internal static class NativeMethods
{
    // Declares managed prototypes for unmanaged functions.
    [DllImport("User32.dll", EntryPoint = "MessageBox",
        CharSet = CharSet.Auto)]
    internal static extern int MsgBox(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);

    // Causes incorrect output in the message window.
    [DllImport("User32.dll", EntryPoint = "MessageBoxW",
        CharSet = CharSet.Ansi)]
    internal static extern int MsgBox2(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);

    // Causes an exception to be thrown. EntryPoint, CharSet, and
    // ExactSpelling fields are mismatched.
    [DllImport("User32.dll", EntryPoint = "MessageBox",
        CharSet = CharSet.Ansi, ExactSpelling = true)]
    internal static extern int MsgBox3(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);
}
//</snippet5>

//<snippet6>
public class MsgBoxSample
{
    public static void Main()
    {
        NativeMethods.MsgBox(0, "Correct text", "MsgBox Sample", 0);
        NativeMethods.MsgBox2(0, "Incorrect text", "MsgBox Sample", 0);

        try
        {
            NativeMethods.MsgBox3(0, "No such function", "MsgBox Sample", 0);
        }
        catch (EntryPointNotFoundException)
        {
            Console.WriteLine($"{nameof(EntryPointNotFoundException)} thrown as expected!");
        }
    }
}
//</snippet6>
//</snippet4>
