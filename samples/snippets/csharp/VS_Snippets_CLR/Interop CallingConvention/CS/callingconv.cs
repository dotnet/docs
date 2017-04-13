// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class LibWrap
{
// C# doesn't support varargs so all arguments must be explicitly defined.
// CallingConvention.Cdecl must be used since the stack is 
// cleaned up by the caller.

// int printf( const char *format [, argument]... )

[DllImport("msvcrt.dll", CharSet=CharSet.Unicode, CallingConvention=CallingConvention.Cdecl)]
public static extern int printf(String format, int i, double d); 

[DllImport("msvcrt.dll", CharSet=CharSet.Unicode, CallingConvention=CallingConvention.Cdecl)]
public static extern int printf(String format, int i, String s); 
}

public class App
{
    public static void Main()
    {
        LibWrap.printf("\nPrint params: %i %f", 99, 99.99);
        LibWrap.printf("\nPrint params: %i %s", 99, "abcd");
    }
}
// </Snippet1>