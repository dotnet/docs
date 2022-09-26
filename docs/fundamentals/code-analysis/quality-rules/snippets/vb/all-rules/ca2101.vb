Imports System.Runtime.InteropServices

Class NativeMethods
    <DllImport("advapi32.dll", CharSet:=CharSet.Auto)>
    Friend Shared Function RegCreateKey(ByVal key As IntPtr, ByVal subKey As String, <Out> ByRef result As IntPtr) As Integer
    <DllImport("advapi32.dll", CharSet:=CharSet.Unicode)>
    Friend Shared Function RegCreateKey2(ByVal key As IntPtr, ByVal subKey As String, <Out> ByRef result As IntPtr) As Integer
End Class
