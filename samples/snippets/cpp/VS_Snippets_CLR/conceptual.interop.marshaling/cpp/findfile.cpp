//<snippet16>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet17>
// Declares a class member for each structure element.
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Auto)]
public ref class FindData
{
public:
    int  fileAttributes;
    // creationTime was an embedded FILETIME structure.
    int  creationTime_lowDateTime;
    int  creationTime_highDateTime;
    // lastAccessTime was an embedded FILETIME structure.
    int  lastAccessTime_lowDateTime;
    int  lastAccessTime_highDateTime;
    // lastWriteTime was an embedded FILETIME structure.
    int  lastWriteTime_lowDateTime;
    int  lastWriteTime_highDateTime;
    int  nFileSizeHigh;
    int  nFileSizeLow;
    int  dwReserved0;
    int  dwReserved1;
    [MarshalAs(UnmanagedType::ByValTStr, SizeConst=260)]
    String^  fileName;
    [MarshalAs(UnmanagedType::ByValTStr, SizeConst=14)]
    String^  alternateFileName;
};

public ref class LibWrap
{
public:
    // Declares a managed prototype for the unmanaged function.
    [DllImport("Kernel32.dll", CharSet=CharSet::Auto)]
    static IntPtr FindFirstFile(String^ fileName, [In, Out]
        FindData^ findFileData);
};
//</snippet17>

//<snippet18>
public ref class App
{
public:
    static void Main()
    {
        FindData^ fd = gcnew FindData();
        IntPtr handle = LibWrap::FindFirstFile("C:\\*.*", fd);
        Console::WriteLine("The first file: {0}", fd->fileName);
    }
};
//</snippet18>
int main()
{
    App::Main();
}
//</snippet16>
