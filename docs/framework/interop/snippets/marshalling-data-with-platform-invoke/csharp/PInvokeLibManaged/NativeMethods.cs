using System.Runtime.InteropServices;

// <ManagedTypes>
// Managed type declarations that correspond to the unmanaged types in PinvokeLib.dll.

[StructLayout(LayoutKind.Sequential)]
internal struct MyPoint
{
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
internal struct MyPerson
{
    public string first;
    public string last;
}

[StructLayout(LayoutKind.Sequential)]
internal struct MyPerson2
{
    public IntPtr person; // Pointer to a MyPerson structure
    public int age;
}

[StructLayout(LayoutKind.Sequential)]
internal struct MyPerson3
{
    public MyPerson person; // Embedded MyPerson structure
    public int age;
}

[StructLayout(LayoutKind.Explicit)]
internal struct MyUnion
{
    [FieldOffset(0)] public int i;
    [FieldOffset(0)] public double d;
}

[StructLayout(LayoutKind.Sequential)]
internal struct MyArrayStruct
{
    public bool flag;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public int[] vals;
}
// </ManagedTypes>

// <NativeMethods>
internal static class NativeMethods
{
    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfInts(
        [In, Out] int[] array, int size);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestRefArrayOfInts(
        ref IntPtr array, ref int size);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestMatrixOfInts(
        [In, Out] int[,] matrix, int row);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfStrings(
        [In, Out] string[] array, int size);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfStructs(
        [In, Out] MyPoint[] pointArray, int size);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfStructs2(
        [In, Out] MyPerson[] personArray, int size);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestStructInStruct(ref MyPerson2 person2);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void TestStructInStruct3(MyPerson3 person3);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void TestUnion(MyUnion u, int type);

    [DllImport("PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern void TestArrayInStruct(ref MyArrayStruct myStruct);
}
// </NativeMethods>
