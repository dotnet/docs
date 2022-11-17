
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

<Assembly: DisableRuntimeMarshalling>

Class C
    Shared Sub S1()
        Dim offset As IntPtr = Marshal.OffsetOf(GetType(ValueType), "field")
    End Sub
End Class

Structure ValueType
    Dim field As Integer
End Structure
