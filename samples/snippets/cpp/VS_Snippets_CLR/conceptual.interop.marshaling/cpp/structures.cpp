//<snippet22>
using namespace System;
using namespace System::Runtime::InteropServices;

//<snippet23>
// Declares a managed structure for each unmanaged structure.
[StructLayout(LayoutKind::Sequential, CharSet=CharSet::Ansi)]
public value struct MyPerson
{
public:
    String^ first;
    String^ last;
};

[StructLayout(LayoutKind::Sequential)]
public value struct MyPerson2
{
public:
    IntPtr person;
    int age;
};

[StructLayout(LayoutKind::Sequential)]
public value struct MyPerson3
{
public:
    MyPerson person;
    int age;
};

[StructLayout(LayoutKind::Sequential)]
public value struct MyArrayStruct
{
public:
    bool flag;
    [MarshalAs(UnmanagedType::ByValArray, SizeConst=3)]
    array<int>^ vals;
};

public ref class LibWrap
{
public:
    // Declares a managed prototype for unmanaged function.
    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static int TestStructInStruct(MyPerson2% person2);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static int TestStructInStruct3(MyPerson3 person3);

    [DllImport("..\\LIB\\PinvokeLib.dll")]
    static int TestArrayInStruct(MyArrayStruct% myStruct);
};
//</snippet23>

//<snippet24>
public ref class App
{
public:
    static void Main()
    {
        // Structure with a pointer to another structure.
        MyPerson personName;
        personName.first = "Mark";
        personName.last = "Lee";

        MyPerson2 personAll;
        personAll.age = 30;

        IntPtr buffer = Marshal::AllocCoTaskMem(Marshal::SizeOf(personName));
        Marshal::StructureToPtr(personName, buffer, false);

        personAll.person = buffer;

        Console::WriteLine("\nPerson before call:");
        Console::WriteLine("first = {0}, last = {1}, age = {2}",
            personName.first, personName.last, personAll.age);

        int res = LibWrap::TestStructInStruct(personAll);

        MyPerson personRes =
            (MyPerson)Marshal::PtrToStructure(personAll.person,
            MyPerson::typeid);

        Marshal::FreeCoTaskMem(buffer);

        Console::WriteLine("Person after call:");
        Console::WriteLine("first = {0}, last = {1}, age = {2}",
            personRes.first, personRes.last, personAll.age);

        // Structure with an embedded structure.
        MyPerson3 person3;// = gcnew MyPerson3();
        person3.person.first = "John";
        person3.person.last = "Evans";
        person3.age = 27;
        LibWrap::TestStructInStruct3(person3);

        // Structure with an embedded array.
        MyArrayStruct myStruct;// = new MyArrayStruct();

        myStruct.flag = false;
        myStruct.vals = gcnew array<int>(3);
        myStruct.vals[0] = 1;
        myStruct.vals[1] = 4;
        myStruct.vals[2] = 9;

        Console::WriteLine("\nStructure with array before call:");
        Console::WriteLine(myStruct.flag);
        Console::WriteLine("{0} {1} {2}", myStruct.vals[0],
            myStruct.vals[1], myStruct.vals[2]);

        LibWrap::TestArrayInStruct(myStruct);
        Console::WriteLine("\nStructure with array after call:");
        Console::WriteLine(myStruct.flag);
        Console::WriteLine("{0} {1} {2}", myStruct.vals[0],
            myStruct.vals[1], myStruct.vals[2]);
    }
};
//</snippet24>
int main()
{
    App::Main();
}
//</snippet22>
