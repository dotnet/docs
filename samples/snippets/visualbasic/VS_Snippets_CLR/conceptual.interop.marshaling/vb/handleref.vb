'<snippet42>
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

'<snippet43>
' Declares a managed structure for the unmanaged structure.
<StructLayout(LayoutKind.Sequential)>
Public Structure Overlapped
    ' ...
End Structure

' Declares a managed class for the unmanaged structure.
<StructLayout(LayoutKind.Sequential)>
Public Class Overlapped2
    ' ...
End Class

Friend Class NativeMethods
    ' Declares a managed prototypes for unmanaged functions.
    ' Because Overlapped is a structure, you cannot pass Nothing as a
    ' parameter. Instead, declares an overloaded method.
    Friend Overloads Declare Ansi Function ReadFile Lib "Kernel32.dll" (
        ByVal hndRef As HandleRef,
        ByVal buffer As StringBuilder,
        ByVal numberOfBytesToRead As Integer,
        ByRef numberOfBytesRead As Integer,
        ByRef flag As Overlapped) As Boolean

    ' Declares an int instead of a structure reference for 'flag'
    Friend Overloads Declare Ansi Function ReadFile Lib "Kernel32.dll" (
        ByVal hndRef As HandleRef,
        ByVal buffer As StringBuilder,
        ByVal numberOfBytesToRead As Integer,
        ByRef numberOfBytesRead As Integer,
        ByVal flag As IntPtr) As Boolean

    ' Because Overlapped2 is a class, you can pass Nothing as a parameter.
    ' No overloading is needed.
    Friend Declare Ansi Function ReadFile2 Lib "Kernel32.dll" Alias "ReadFile" (
        ByVal hndRef As HandleRef,
        ByVal buffer As StringBuilder,
        ByVal numberOfBytesToRead As Integer,
        ByRef numberOfBytesRead As Integer,
        <[In], Out> ByVal flag As Overlapped2) As Boolean
End Class
'</snippet43>

'<snippet44>
Public Class App
    Public Shared Sub Main()
        Dim fs As New FileStream("HandleRef.txt", FileMode.Open)
        ' Wraps the FileStream handle in HandleRef to prevent it
        ' from being garbage collected before the call ends.
        Dim hr As New HandleRef(fs, fs.SafeFileHandle.DangerousGetHandle())
        Dim buffer As New StringBuilder(5)
        Dim read As Integer = 0
        ' Platform invoke holds the reference to HandleRef until the
        ' call ends.
        NativeMethods.ReadFile(hr, buffer, 5, read, IntPtr.Zero)
        Console.WriteLine($"Read {read} bytes with struct parameter: {buffer}")
        NativeMethods.ReadFile2(hr, buffer, 5, read, Nothing)
        Console.WriteLine($"Read {read} bytes with class parameter: {buffer}")
    End Sub
End Class
'</snippet44>
'</snippet42>
