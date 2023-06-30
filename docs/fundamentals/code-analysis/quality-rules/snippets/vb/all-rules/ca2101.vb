Imports System
Imports System.Runtime.InteropServices

Namespace ca2101
    '<snippet2>
    Friend Class NativeMethods
        ' Violates rule: SpecifyMarshalingForPInvokeStringArguments.
        <DllImport("advapi32.dll", CharSet:=CharSet.Auto)>
        Friend Shared Function RegCreateKey(ByVal key As IntPtr, ByVal subKey As String, <Out> ByRef result As IntPtr) As Integer
        End Function

        ' Satisfies rule: SpecifyMarshalingForPInvokeStringArguments.
        <DllImport("advapi32.dll", CharSet:=CharSet.Unicode)>
        Friend Shared Function RegCreateKey2(ByVal key As IntPtr, ByVal subKey As String, <Out> ByRef result As IntPtr) As Integer
        End Function
    End Class
    '</snippet2>
End Namespace
