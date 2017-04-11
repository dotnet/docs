// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

public ref class LibWrap
{
    // Managed class methods don't support varargs so all arguments must be
    // explicitly defined. CallingConvention.Cdecl must be used since the
    // stack is cleaned up by the caller.
    // int printf(const char *format [, argument]...)
    public:
        [DllImport("msvcrt.dll", CharSet=CharSet::Ansi,
        CallingConvention=CallingConvention::Cdecl)]
        static int printf(String^ format, int i, double d);
        [DllImport("msvcrt.dll", CharSet=CharSet::Ansi,
        CallingConvention=CallingConvention::Cdecl)]
        static int printf(String^ format, int i, String^ s);
};

void main()
{
    LibWrap::printf("\nPrint params: %i %f", 99, 99.99);
    LibWrap::printf("\nPrint params: %i %s", 99, "abcd");
}
// </Snippet1>

// <Snippet2>
[DllImport("unmanaged.dll, MyAssembly, Version= 1.0.0.0,"
 "Culture=neutral, PublicKeyToken=a77e0ba5eab10125")]
int SomeFuncion1(int parm);
// </Snippet2>

// <Snippet3>
[DllImport("My.dll", CharSet=CharSet::Ansi,
               BestFitMapping=false,
               ThrowOnUnmappableChar=true)]
int SomeFuncion2(int parm);
// </Snippet3>

[DllImport("msvcrt.dll", CharSet=CharSet::Ansi,
CallingConvention=CallingConvention::Cdecl)]
int printf(String^ format, ...);


namespace znippet4
{
// <Snippet4>
[DllImport("user32.dll", CharSet=CharSet::Ansi, ExactSpelling=true)]
int MessageBoxA(IntPtr hWnd, String^ Text,
                String^ Caption, unsigned int Type);
// </Snippet4>
}

namespace znippet5
{
// <Snippet5>
[DllImport("user32.dll", SetLastError=true)]
int MessageBoxA(IntPtr hWnd, String^ Text,
                String^ Caption, unsigned int Type);
// </Snippet5>
}


