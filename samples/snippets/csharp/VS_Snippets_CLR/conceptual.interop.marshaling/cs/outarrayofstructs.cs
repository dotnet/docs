//<snippet19>
using System;
using System.Runtime.InteropServices;

//<snippet20>
// Declares a class member for each structure element.
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public class MyStruct
{
    public string buffer;
    public int size;
}

// Declares a structure with a pointer.
[StructLayout(LayoutKind.Sequential)]
public struct MyUnsafeStruct
{
    public IntPtr buffer;
    public int size;
}

internal static unsafe class NativeMethods
{
    // Declares managed prototypes for the unmanaged function.
    [DllImport("..\\LIB\\PInvokeLib.dll")]
    internal static extern void TestOutArrayOfStructs(
        out int size, out IntPtr outArray);

    [DllImport("..\\LIB\\PInvokeLib.dll")]
    internal static extern void TestOutArrayOfStructs(
        out int size, MyUnsafeStruct** outArray);
}
//</snippet20>

//<snippet21>
public class App
{
    public static void Main()
    {
        Console.WriteLine("\nUsing marshal class\n");
        UsingMarshaling();
        Console.WriteLine("\nUsing unsafe code\n");
        UsingUnsafePointer();
    }

    public static void UsingMarshaling()
    {
        int size;
        IntPtr outArray;

        NativeMethods.TestOutArrayOfStructs(out size, out outArray);
        MyStruct[] manArray = new MyStruct[size];
        IntPtr current = outArray;
        for (int i = 0; i < size; i++)
        {
            manArray[i] = new MyStruct();
            Marshal.PtrToStructure(current, manArray[i]);

            //Marshal.FreeCoTaskMem((IntPtr)Marshal.ReadInt32(current));
            Marshal.DestroyStructure(current, typeof(MyStruct));
            current = (IntPtr)((long)current + Marshal.SizeOf(manArray[i]));

            Console.WriteLine($"Element {i}: {manArray[i].buffer} {manArray[i].size}");
        }

        Marshal.FreeCoTaskMem(outArray);
    }

    public static unsafe void UsingUnsafePointer()
    {
        int size;
        MyUnsafeStruct* pResult;

        NativeMethods.TestOutArrayOfStructs(out size, &pResult);
        MyUnsafeStruct* pCurrent = pResult;
        for (int i = 0; i < size; i++, pCurrent++)
        {
            Console.WriteLine($"Element {i}: {Marshal.PtrToStringAnsi(pCurrent->buffer)} {pCurrent->size}");
            Marshal.FreeCoTaskMem(pCurrent->buffer);
        }

        Marshal.FreeCoTaskMem((IntPtr)pResult);
    }
}
//</snippet21>
//</snippet19>
