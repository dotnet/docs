// <Snippet1>
using System;
using System.Runtime.InteropServices;

public class LibWrap
{
    // C# doesn't support varargs so all arguments must be explicitly defined.
    // CallingConvention.Cdecl must be used since the stack is
    // cleaned up by the caller.
    // int printf(const char *format [, argument]...)
    [DllImport("msvcrt.dll", CharSet=CharSet.Ansi,
    CallingConvention=CallingConvention.Cdecl)]
    public static extern int printf(String format, int i, double d);
    [DllImport("msvcrt.dll", CharSet=CharSet.Ansi,
    CallingConvention=CallingConvention.Cdecl)]
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

public class TheClass
{
    // <Snippet2>
    [DllImport("unmanaged.dll, MyAssembly, Version= 1.0.0.0," +
     "Culture=neutral, PublicKeyToken=a77e0ba5eab10125")]
    static extern int SomeFuncion1(int parm);
    // </Snippet2>

    // <Snippet3>
    [DllImport("My.dll", CharSet=CharSet.Ansi,
                   BestFitMapping=false,
                   ThrowOnUnmappableChar=true)]
    static extern int SomeFuncion2(int parm);
    // </Snippet3>
}

namespace znippet4
{
// <Snippet4>
public class Win32
{
    [DllImport("user32.dll", CharSet=CharSet.Unicode,
        ExactSpelling=true)]
    public static extern int MessageBoxW(IntPtr hWnd, String text,
                                String caption, uint type);
}
// </Snippet4>
}

namespace znippet5
{
// <Snippet5>
public class Win32
{
    [DllImport("user32.dll", SetLastError=true)]
    public static extern int MessageBoxA(IntPtr hWnd, String text,
                                String caption, uint type);
}
// </Snippet5>
}
