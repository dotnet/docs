'<snippet10>
Imports System.Runtime.InteropServices

'<snippet11>
<StructLayout(LayoutKind.Sequential)>
Public Class OSVersionInfo
    Public OSVersionInfoSize As Integer
    Public MajorVersion As Integer
    Public MinorVersion As Integer
    Public BuildNumber As Integer
    Public PlatformId As Integer

    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
    Public CSDVersion As String
End Class

<StructLayout(LayoutKind.Sequential)>
Public Structure OSVersionInfo2
    Public OSVersionInfoSize As Integer
    Public MajorVersion As Integer
    Public MinorVersion As Integer
    Public BuildNumber As Integer
    Public PlatformId As Integer

    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
    Public CSDVersion As String
End Structure

Friend Class NativeMethods
    Friend Declare Ansi Function GetVersionEx Lib "kernel32" Alias _
        "GetVersionExA" (<[In], Out> ByVal osvi As OSVersionInfo) As Boolean

    Friend Declare Ansi Function GetVersionEx2 Lib "kernel32" Alias _
        "GetVersionExA" (ByRef osvi As OSVersionInfo2) As Boolean
End Class
'</snippet11>

'<snippet12>
Public Class App
    Public Shared Sub Main()
        Console.WriteLine(vbNewLine + "Passing OSVersionInfo as a class")

        Dim osvi As New OSVersionInfo()
        osvi.OSVersionInfoSize = Marshal.SizeOf(osvi)

        NativeMethods.GetVersionEx(osvi)

        Console.WriteLine("Class size:    {0}", osvi.OSVersionInfoSize)
        Console.WriteLine("OS Version:    {0}.{1}", osvi.MajorVersion, osvi.MinorVersion)

        Console.WriteLine(vbNewLine + "Passing OSVersionInfo2 as a struct")

        Dim osvi2 As New OSVersionInfo2()
        osvi2.OSVersionInfoSize = Marshal.SizeOf(osvi2)

        NativeMethods.GetVersionEx2(osvi2)
        Console.WriteLine("Struct size:   {0}", osvi2.OSVersionInfoSize)
        Console.WriteLine("OS Version:    {0}.{1}", osvi2.MajorVersion, osvi2.MinorVersion)
    End Sub
End Class
'</snippet12>
'</snippet10>
