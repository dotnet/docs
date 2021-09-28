'<snippet16>
Imports System.Runtime.InteropServices

'<snippet17>
' Declares a class member for each structure element.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
Public Class FindData
    Public fileAttributes As Integer = 0
    ' creationTime was a by-value FILETIME structure.
    Public creationTime_lowDateTime As Integer = 0
    Public creationTime_highDateTime As Integer = 0
    ' lastAccessTime was a by-value FILETIME structure.
    Public lastAccessTime_lowDateTime As Integer = 0
    Public lastAccessTime_highDateTime As Integer = 0
    ' lastWriteTime was a by-value FILETIME structure.
    Public lastWriteTime_lowDateTime As Integer = 0
    Public lastWriteTime_highDateTime As Integer = 0
    Public nFileSizeHigh As Integer = 0
    Public nFileSizeLow As Integer = 0
    Public dwReserved0 As Integer = 0
    Public dwReserved1 As Integer = 0
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
    Public fileName As String = Nothing
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)>
    Public alternateFileName As String = Nothing
End Class

Friend Class NativeMethods
    ' Declares a managed prototype for the unmanaged function.
    Friend Declare Auto Function FindFirstFile Lib "Kernel32.dll" (
        ByVal fileName As String, <[In], Out> ByVal findFileData As _
        FindData) As IntPtr
End Class
'</snippet17>

'<snippet18>
Public Class App
    Public Shared Sub Main()
        Dim fd As New FindData()
        Dim handle As IntPtr = NativeMethods.FindFirstFile("C:\*.*", fd)
        Console.WriteLine($"The first file: {fd.fileName}")
    End Sub
End Class
'</snippet18>
'</snippet16>
