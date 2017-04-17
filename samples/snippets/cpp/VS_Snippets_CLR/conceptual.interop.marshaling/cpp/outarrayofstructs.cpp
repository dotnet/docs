//<snippet19>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet20>
// Declares a class member for each structure element.
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Ansi)]
public ref class MyStruct
{
public:
    String^ buffer;
    int size;
};

// Declares a structure with a pointer.
[StructLayout(LayoutKind::Sequential)]
public value struct MyUnsafeStruct
{
public:
    IntPtr buffer;
    int size;
};

public ref class LibWrap
{
public:
    // Declares managed prototypes for the unmanaged function.
    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void TestOutArrayOfStructs(int% size,
        IntPtr% outArray);

    [DllImport("..\\LIB\\PInvokeLib.dll")]
    static void TestOutArrayOfStructs(int% size,
        MyUnsafeStruct** outArray);
};
//</snippet20>

//<snippet21>
public ref class App
{
public:
    static void Main()
    {
        Console::WriteLine("\nUsing marshal class\n");
        UsingMarshaling();
        Console::WriteLine("\nUsing unsafe code\n");
        UsingUnsafePointer();
    }

    static void UsingMarshaling()
    {
        int size;
        IntPtr outArray;

        LibWrap::TestOutArrayOfStructs(size, outArray);
        array<MyStruct^>^ manArray = gcnew array<MyStruct^>(size);
        IntPtr current = outArray;
        for (int i = 0; i < size; i++)
        {
            manArray[i] = gcnew MyStruct();
            Marshal::PtrToStructure(current, manArray[i]);

            Marshal::DestroyStructure(current, MyStruct::typeid);
            //current = (IntPtr)((long)current + Marshal::SizeOf(manArray[i]));
            current = current + Marshal::SizeOf(manArray[i]);

            Console::WriteLine("Element {0}: {1} {2}", i, manArray[i]->buffer,
                manArray[i]->size);
        }
        Marshal::FreeCoTaskMem(outArray);
    }

    static void UsingUnsafePointer()
    {
        int size;
        MyUnsafeStruct* pResult;

        LibWrap::TestOutArrayOfStructs(size, &pResult);
        MyUnsafeStruct* pCurrent = pResult;
        for (int i = 0; i < size; i++, pCurrent++)
        {
            Console::WriteLine("Element {0}: {1} {2}", i,
                Marshal::PtrToStringAnsi(pCurrent->buffer), pCurrent->size);
            Marshal::FreeCoTaskMem(pCurrent->buffer);
        }
        Marshal::FreeCoTaskMem((IntPtr)pResult);
    }
};
//</snippet21>
int main()
{
    App::Main();
}
//</snippet19>
