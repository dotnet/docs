//<snippet36>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet37>
public delegate bool FPtr(int value);
public delegate bool FPtr2(String^ value);

private ref class NativeMethods
{
public:
    // Declares managed prototypes for unmanaged functions.
    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static void TestCallBack(FPtr^ cb, int value);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static void TestCallBack2(FPtr2^ cb2, String^ value);
};
//</snippet37>

//<snippet38>
public ref class App
{
public:
    static void Main()
    {
        FPtr^ cb = gcnew FPtr(&App::DoSomething);
        NativeMethods::TestCallBack(cb, 99);
        FPtr2^ cb2 = gcnew FPtr2(&App::DoSomething2);
        NativeMethods::TestCallBack2(cb2, "abc");
    }

    static bool DoSomething(int value)
    {
        Console::WriteLine("\nCallback called with param: {0}", value);
        // ...
        return true;
    }

    static bool DoSomething2(String^ value)
    {
        Console::WriteLine("\nCallback called with param: {0}", value);
        // ...
        return true;
    }
};
//</snippet38>
int main()
{
    App::Main();
}
//</snippet36>
