//<snippet4>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet5>
public ref class LibWrap
{
public:
    // Declares managed prototypes for unmanaged functions.
    [DllImport( "User32.dll", EntryPoint="MessageBox",
        CharSet=CharSet::Auto)]
    static int MsgBox(int hWnd, String^ text, String^ caption,
      unsigned int type);

    // Causes incorrect output in the message window.
    [DllImport( "User32.dll", EntryPoint="MessageBoxW",
        CharSet=CharSet::Ansi )]
    static int MsgBox2(int hWnd, String^ text,
       String^ caption, unsigned int type);

    // Causes an exception to be thrown. EntryPoint, CharSet, and
    // ExactSpelling fields are mismatched.
    [DllImport( "User32.dll", EntryPoint="MessageBox",
        CharSet=CharSet::Ansi, ExactSpelling=true )]
    static int MsgBox3(int hWnd, String^ text,
        String^ caption, unsigned int type);
};
//</snippet5>

//<snippet6>
public class MsgBoxSample
{
public:
    static void Main()
    {
        LibWrap::MsgBox(0, "Correct text", "MsgBox Sample", 0);
        LibWrap::MsgBox2(0, "Incorrect text", "MsgBox Sample", 0);

        try
        {
            LibWrap::MsgBox3(0, "No such function", "MsgBox Sample", 0);
        }
        catch (EntryPointNotFoundException^)
        {
           Console::WriteLine("EntryPointNotFoundException thrown as expected!");
        }
    }
};
//</snippet6>

int main()
{
    MsgBoxSample::Main();
}
//</snippet4>
