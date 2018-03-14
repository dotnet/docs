'<snippet42>
Imports System
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

'<snippet43>
' Declares a managed structure for the unmanaged structure.
<StructLayout(LayoutKind.Sequential)> _
Public Structure Overlapped
    ' ...
End Structure

' Declares a managed class for the unmanaged structure.
<StructLayout(LayoutKind.Sequential)> _
Public Class Overlapped2
    ' ...
End Class

Public Class LibWrap
    ' Declares a managed prototypes for unmanaged functions.
    ' Because Overlapped is a structure, you cannot pass Nothing as a
    ' parameter. Instead, declares an overloaded method.
    Overloads Declare Ansi Function ReadFile Lib "Kernel32.dll" ( _
        ByVal hndRef As HandleRef, _
        ByVal buffer As StringBuilder, _
        ByVal numberOfBytesToRead As Integer, _
        ByRef numberOfBytesRead As Integer, _
        ByRef flag As Overlapped) As Boolean

    ' Declares an int instead of a structure reference for 'flag'
    Overloads Declare Ansi Function ReadFile Lib "Kernel32.dll" ( _
        ByVal hndRef As HandleRef, _
        ByVal buffer As StringBuilder, _
        ByVal numberOfBytesToRead As Integer, _
        ByRef numberOfBytesRead As Integer, _
        ByVal flag As IntPtr) As Boolean

    ' Because Overlapped2 is a class, you can pass Nothing as a parameter.
    ' No overloading is needed.
    Declare Ansi Function ReadFile2 Lib "Kernel32.dll" Alias "ReadFile" ( _
        ByVal hndRef As HandleRef, _
        ByVal buffer As StringBuilder, _
        ByVal numberOfBytesToRead As Integer, _
        ByRef numberOfBytesRead As Integer, _
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
        LibWrap.ReadFile(hr, buffer, 5, read, IntPtr.Zero)
        Console.WriteLine("Read {0} bytes with struct parameter: {1}", read, buffer)
        LibWrap.ReadFile2(hr, buffer, 5, read, Nothing)
        Console.WriteLine("Read {0} bytes with class parameter: {1}", read, buffer)
    End Sub
End Class
'</snippet44>
'</snippet42>
