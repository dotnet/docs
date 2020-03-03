// <Snippet1>
using System;
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    // C# doesn't support varargs so all arguments must be explicitly defined.
    // CallingConvention.Cdecl must be used since the stack is 
    // cleaned up by the caller.

    // int printf( const char *format [, argument]... )

    [DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    internal static extern int printf(String format, int i, double d);

    [DllImport("msvcrt.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
    internal static extern int printf(String format, int i, String s);
}

public class App
{
    public static void Main()
    {
        NativeMethods.printf("\nPrint params: %i %f", 99, 99.99);
        NativeMethods.printf("\nPrint params: %i %s", 99, "abcd");
    }
}
// </Snippet1>
