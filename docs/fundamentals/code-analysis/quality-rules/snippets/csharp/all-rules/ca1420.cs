using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

[assembly: DisableRuntimeMarshalling]

class C
{
    // Violates rule CA1420.
    [DllImport("NativeLibrary", SetLastError = true)]
    public static extern void MyMethod ();
}
