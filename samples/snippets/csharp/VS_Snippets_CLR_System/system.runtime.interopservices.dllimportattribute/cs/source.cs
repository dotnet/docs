// <Snippet1>
using System;
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    // C# doesn't support varargs so all arguments must be explicitly defined.
    // CallingConvention.Cdecl must be used since the stack is
    // cleaned up by the caller.
    // int printf(const char *format [, argument]...)
    [DllImport("msvcrt.dll", CharSet = CharSet.Ansi,
        CallingConvention = CallingConvention.Cdecl)]
    internal static extern int printf(string format, int i, double d);

    [DllImport("msvcrt.dll", CharSet = CharSet.Ansi,
        CallingConvention = CallingConvention.Cdecl)]
    internal static extern int printf(string format, int i, string s);
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

public class TheClass
{
    // <Snippet2>
    [DllImport("unmanaged.dll, MyAssembly, Version= 1.0.0.0," +
        "Culture=neutral, PublicKeyToken=a77e0ba5eab10125")]
    internal static extern int SomeFuncion1(int parm);
    // </Snippet2>

    // <Snippet3>
    [DllImport("My.dll", CharSet = CharSet.Ansi,
        BestFitMapping = false,
        ThrowOnUnmappableChar = true)]
    internal static extern int SomeFuncion2(int parm);
    // </Snippet3>
}

namespace znippet4
{
    // <Snippet4>
    internal static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode,
            ExactSpelling = true)]
        internal static extern int MessageBoxW(
            IntPtr hWnd, string lpText, string lpCption, uint uType);
    }
    // </Snippet4>
}

namespace znippet5
{
    // <Snippet5>
    internal static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int MessageBoxA(
            IntPtr hWnd, string lpText, string lpCaption, uint uType);
    }
    // </Snippet5>
}
