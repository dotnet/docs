Public Class Class5
    ' 7e5cf519-8b64-4ac5-8116-705fe26c846d
    ' 'As Any' is not supported in 'Declare' statements

    ' <snippet95>
    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (
        ByVal lpBuffer As String,
        ByRef nSize As Integer) As Integer
    ' </snippet95>

    ' <snippet96>
    Declare Sub SetData Lib "..\LIB\UnmgdLib.dll" (
        ByVal x As Short,
        <System.Runtime.InteropServices.MarshalAsAttribute(
            System.Runtime.InteropServices.UnmanagedType.AsAny)>
            ByVal o As Object)
    ' </snippet96>
End Class
