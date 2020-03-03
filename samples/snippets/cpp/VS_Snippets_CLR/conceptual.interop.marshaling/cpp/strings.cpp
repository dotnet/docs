//<snippet13>
using namespace System;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

//<snippet14>
// Declares a managed structure for each unmanaged structure.
[StructLayout(LayoutKind::Sequential, CharSet = CharSet::Unicode)]
public value struct MyStrStruct
{
public:
    String^ buffer;
    int size;
};

[StructLayout(LayoutKind::Sequential, CharSet = CharSet::Ansi)]
public value struct MyStrStruct2
{
public:
    String^ buffer;
    int size;
};

private ref class NativeMethods
{
public:
    // Declares managed prototypes for unmanaged functions.
    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static String^ TestStringAsResult();

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static void TestStringInStruct(MyStrStruct% mss);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static void TestStringInStructAnsi(MyStrStruct2% mss);
};
//</snippet14>

//<snippet15>
public ref class App
{
public:
    static void Main()
    {
        // String as result.
        String^ str = NativeMethods::TestStringAsResult();
        Console::WriteLine("\nString returned: {0}", str);

        // Initializes buffer and appends something to the end so the whole
        // buffer is passed to the unmanaged side.
        StringBuilder^ buffer = gcnew StringBuilder("content", 100);
        buffer->Append((char)0);
        buffer->Append('*', buffer->Capacity - 8);

        MyStrStruct mss;
        mss.buffer = buffer->ToString();
        mss.size = mss.buffer->Length;

        NativeMethods::TestStringInStruct(mss);
        Console::WriteLine("\nBuffer after Unicode function call: {0}",
            mss.buffer);

        StringBuilder^ buffer2 = gcnew StringBuilder("content", 100);
        buffer2->Append((char)0);
        buffer2->Append('*', buffer2->Capacity - 8);

        MyStrStruct2 mss2;
        mss2.buffer = buffer2->ToString();
        mss2.size = mss2.buffer->Length;

        NativeMethods::TestStringInStructAnsi(mss2);
        Console::WriteLine("\nBuffer after Ansi function call: {0}",
            mss2.buffer);
    }
};
//</snippet15>
int main()
{
    App::Main();
}
//</snippet13>
