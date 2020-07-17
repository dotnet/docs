//<snippet10>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet11>
[StructLayout(LayoutKind::Sequential)]
public ref class OSVersionInfo
{
public:
    int OSVersionInfoSize;
    int MajorVersion;
    int MinorVersion;
    int BuildNumber;
    int PlatformId;

    [MarshalAs(UnmanagedType::ByValTStr, SizeConst = 128)]
    String^ CSDVersion;
};

[StructLayout(LayoutKind::Sequential)]
public value struct OSVersionInfo2
{
public:
    int OSVersionInfoSize;
    int MajorVersion;
    int MinorVersion;
    int BuildNumber;
    int PlatformId;

    [MarshalAs(UnmanagedType::ByValTStr, SizeConst = 128)]
    String^ CSDVersion;
};

private ref class NativeMethods
{
public:
    [DllImport("kernel32")]
    static bool GetVersionEx([In, Out] OSVersionInfo^ osvi);

    [DllImport("kernel32", EntryPoint = "GetVersionEx")]
    static bool GetVersionEx2(OSVersionInfo2% osvi);
};
//</snippet11>

//<snippet12>
public ref class App
{
public:
    static void Main()
    {
        Console::WriteLine("\nPassing OSVersionInfo as a class");

        OSVersionInfo^ osvi = gcnew OSVersionInfo();
        osvi->OSVersionInfoSize = Marshal::SizeOf(osvi);

        NativeMethods::GetVersionEx(osvi);

        Console::WriteLine("Class size:    {0}", osvi->OSVersionInfoSize);
        Console::WriteLine("OS Version:    {0}.{1}", osvi->MajorVersion, osvi->MinorVersion);

        Console::WriteLine("\nPassing OSVersionInfo as a struct");

        OSVersionInfo2 osvi2;
        osvi2.OSVersionInfoSize = Marshal::SizeOf(osvi2);

        NativeMethods::GetVersionEx2(osvi2);
        Console::WriteLine("Struct size:   {0}", osvi2.OSVersionInfoSize);
        Console::WriteLine("OS Version:    {0}.{1}", osvi2.MajorVersion, osvi2.MinorVersion);
    }
};
//</snippet12>
int main()
{
    App::Main();
}
//</snippet10>
