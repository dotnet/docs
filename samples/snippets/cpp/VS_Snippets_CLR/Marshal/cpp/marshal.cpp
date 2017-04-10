//Types:System.Runtime.InteropServices.Marshal Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

public value struct Point
{
public:
    property int X;
    property int Y;
};
//<snippet5>
extern bool CloseHandle(IntPtr h);

int main()
{
    //<snippet2> 
    // Demonstrate the use of public static fields of the Marshal
    // class.
    Console::WriteLine(
        "SystemDefaultCharSize={0},SystemMaxDBCSCharSize={1}",
        Marshal::SystemDefaultCharSize,
        Marshal::SystemMaxDBCSCharSize);
    //</snippet2>

    //<snippet3> 
    // Demonstrate the use of the SizeOf method of the Marshal
    // class.
    Console::WriteLine("Number of bytes needed by a Point object: {0}",
        Marshal::SizeOf(Point::typeid));
    Point point;
    Console::WriteLine("Number of bytes needed by a Point object: {0}",
        Marshal::SizeOf(point));
    //</snippet3>

    //<snippet4>
    // Demonstrate how to call GlobalAlloc and 
    // GlobalFree using the Marshal class.
    IntPtr hglobal = Marshal::AllocHGlobal(100);
    Marshal::FreeHGlobal(hglobal);
    //</snippet4>

    // Demonstrate how to use the Marshal class to get the Win32
    // error code when a Win32 method fails.
    bool isCloseHandleSuccess = CloseHandle(IntPtr(-1));
    if (!isCloseHandleSuccess)
    {
        Console::WriteLine(
            "CloseHandle call failed with an error code of: {0}",
            Marshal::GetLastWin32Error());
    }
};

// This is a platform invoke prototype. SetLastError is true,
// which allows the GetLastWin32Error method of the Marshal class
// to work correctly.    
[DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
extern bool CloseHandle(IntPtr h);
//</snippet5>

// This code produces the following output.
// 
// SystemDefaultCharSize=2, SystemMaxDBCSCharSize=1
// Number of bytes needed by a Point object: 8
// Number of bytes needed by a Point object: 8
// CloseHandle call failed with an error code of: 6
//</snippet1>
