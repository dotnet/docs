//<snippet1>
using namespace System;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

//<snippet2>
private ref class NativeMethods
{
public:
    [DllImport("Kernel32.dll", CharSet = CharSet::Auto)]
    static int GetSystemDirectory(StringBuilder^ sysDirBuffer, int size);

    [DllImport("Kernel32.dll", CharSet = CharSet::Auto)]
    static IntPtr GetCommandLine();
};
//</snippet2>

//<snippet3>
public ref class App
{
public:
    static void Main()
    {
        // Call GetSystemDirectory.
        StringBuilder^ sysDirBuffer = gcnew StringBuilder(256);
        NativeMethods::GetSystemDirectory(sysDirBuffer, sysDirBuffer->Capacity);
        // ...
        // Call GetCommandLine.
        IntPtr cmdLineStr = NativeMethods::GetCommandLine();
        String^ commandLine = Marshal::PtrToStringAuto(cmdLineStr);
    }
};
//</snippet3>

int main()
{
    App::Main();
}
//</snippet1>
