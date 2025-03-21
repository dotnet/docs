//<snippet22>
using System;
using System.Runtime.InteropServices;

//<snippet23>
// Declares a managed structure for each unmanaged structure.
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MyPerson
{
    public string first;
    public string last;
}

[StructLayout(LayoutKind.Sequential)]
public struct MyPerson2
{
    public IntPtr person;
    public int age;
}

[StructLayout(LayoutKind.Sequential)]
public struct MyPerson3
{
    public MyPerson person;
    public int age;
}

[StructLayout(LayoutKind.Sequential)]
public struct MyArrayStruct
{
    public bool flag;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] vals;
}

internal static class NativeMethods
{
    // Declares a managed prototype for unmanaged function.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestStructInStruct(ref MyPerson2 person2);

    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestStructInStruct3(MyPerson3 person3);

    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayInStruct(ref MyArrayStruct myStruct);
}
//</snippet23>

//<snippet24>
public class App
{
    public static void Main()
    {
        // Structure with a pointer to another structure.
        MyPerson personName;
        personName.first = "Mark";
        personName.last = "Lee";

        MyPerson2 personAll;
        personAll.age = 30;

        IntPtr buffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(personName));
        Marshal.StructureToPtr(personName, buffer, false);

        personAll.person = buffer;

        Console.WriteLine("\nPerson before call:");
        Console.WriteLine("first = {0}, last = {1}, age = {2}",
            personName.first, personName.last, personAll.age);

        int res = NativeMethods.TestStructInStruct(ref personAll);

        MyPerson personRes =
            (MyPerson)Marshal.PtrToStructure(personAll.person,
            typeof(MyPerson));

        Marshal.FreeCoTaskMem(buffer);

        Console.WriteLine("Person after call:");
        Console.WriteLine("first = {0}, last = {1}, age = {2}",
            personRes.first, personRes.last, personAll.age);

        // Structure with an embedded structure.
        MyPerson3 person3 = new MyPerson3();
        person3.person.first = "John";
        person3.person.last = "Evans";
        person3.age = 27;
        NativeMethods.TestStructInStruct3(person3);

        // Structure with an embedded array.
        MyArrayStruct myStruct = new MyArrayStruct();

        myStruct.flag = false;
        myStruct.vals = new int[3];
        myStruct.vals[0] = 1;
        myStruct.vals[1] = 4;
        myStruct.vals[2] = 9;

        Console.WriteLine("\nStructure with array before call:");
        Console.WriteLine(myStruct.flag);
        Console.WriteLine($"{myStruct.vals[0]} {myStruct.vals[1]} {myStruct.vals[2]}");

        NativeMethods.TestArrayInStruct(ref myStruct);
        Console.WriteLine("\nStructure with array after call:");
        Console.WriteLine(myStruct.flag);
        Console.WriteLine($"{myStruct.vals[0]} {myStruct.vals[1]} {myStruct.vals[2]}");
    }
}
//</snippet24>
//</snippet22>
