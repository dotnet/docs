using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: DisableRuntimeMarshalling]

class C
{
    // Violates rule CA1420.
    [DllImport("NativeLibrary", SetLastError = true)]
    public static extern void MyMethod();
}
