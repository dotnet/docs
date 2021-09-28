//<snippet25>
using namespace System;
using namespace System::Runtime::InteropServices;     // For StructLayout, DllImport

[StructLayout(LayoutKind::Sequential)]
public ref class SystemTime
{
public:
    unsigned short year;
    unsigned short month;
    unsigned short weekday;
    unsigned short day;
    unsigned short hour;
    unsigned short minute;
    unsigned short second;
    unsigned short millisecond;
};

public class NativeMethods
{
public:
    // Declares a managed prototype for the unmanaged function using Platform Invoke.
    [DllImport("Kernel32.dll")]
    static void GetSystemTime([In, Out] SystemTime^ st);
};

public class App
{
public:
    static void Main()
    {
        Console::WriteLine("C++/CLI SysTime Sample using Platform Invoke");
        SystemTime^ st = gcnew SystemTime();
        NativeMethods::GetSystemTime(st);
        Console::Write("The Date is: ");
        Console::Write("{0} {1} {2}", st->month, st->day, st->year);
    }
};

int main()
{
    App::Main();
}
// The program produces output similar to the following:
//
// C++/CLI SysTime Sample using Platform Invoke
// The Date is: 3 21 2010
//</snippet25>
