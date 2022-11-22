Imports System.Runtime.InteropServices
Imports System.Runtime.CompilerServices

<Assembly: DisableRuntimeMarshalling>

Class C
    ' Violates rule CA1420.
    <DllImport("NativeLibrary", SetLastError:=True)>
    Public Shared Sub MyMethod()
        '...
    End Sub
End Class
