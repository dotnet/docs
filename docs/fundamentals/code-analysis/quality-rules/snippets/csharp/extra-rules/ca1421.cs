using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: DisableRuntimeMarshalling]

class C
{
    public void Test()
    {
        nint offset = Marshal.OffsetOf(typeof(ValueType), "field");
    }
}

struct ValueType
{
    int field;
}
