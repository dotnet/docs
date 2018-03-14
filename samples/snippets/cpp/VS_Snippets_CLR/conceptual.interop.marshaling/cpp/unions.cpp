//<snippet26>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet28>
// Declares managed structures instead of unions.
[StructLayout(LayoutKind::Explicit)]
public value struct MyUnion
{
public:
    [FieldOffset(0)]
    int i;
    [FieldOffset(0)]
    double d;
};

[StructLayout(LayoutKind::Explicit, Size=128)]
public value struct MyUnion2_1
{
public:
    [FieldOffset(0)]
    int i;
};

[StructLayout(LayoutKind::Sequential)]
public value struct MyUnion2_2
{
public:
    [MarshalAs(UnmanagedType::ByValTStr, SizeConst=128)]
    String^ str;
};

public ref class LibWrap
{
public:
    // Declares managed prototypes for unmanaged function.
    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void TestUnion(MyUnion u, int type);

    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void TestUnion2(MyUnion2_1 u, int type);

    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void TestUnion2(MyUnion2_2 u, int type);
};
//</snippet28>

//<snippet29>
public ref class App
{
public:
    static void Main()
    {
        MyUnion mu;// = new MyUnion();
        mu.i = 99;
        LibWrap::TestUnion(mu, 1);

        mu.d = 99.99;
        LibWrap::TestUnion(mu, 2);

        MyUnion2_1 mu2_1;// = new MyUnion2_1();
        mu2_1.i = 99;
        LibWrap::TestUnion2(mu2_1, 1);

        MyUnion2_2 mu2_2;// = new MyUnion2_2();
        mu2_2.str = "*** string ***";
        LibWrap::TestUnion2(mu2_2, 2);
    }
};
//</snippet29>
int main()
{
    App::Main();
}
//</snippet26>
