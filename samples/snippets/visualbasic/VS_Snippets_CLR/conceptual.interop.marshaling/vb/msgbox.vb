'<snippet4>
Imports System.Runtime.InteropServices

'<snippet5>
Friend Class NativeMethods
    ' Declares managed prototypes for unmanaged functions.
    Friend Declare Auto Function MsgBox Lib "User32.dll" Alias "MessageBox" (
        ByVal hWnd As IntPtr, ByVal lpText As String, ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer

    ' Causes incorrect output in the message window.
    Friend Declare Ansi Function MsgBox2 Lib "User32.dll" Alias "MessageBoxW" (
        ByVal hWnd As IntPtr, ByVal lpText As String, ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer

    ' Causes an exception to be thrown.
    ' ExactSpelling is True by default when Ansi or Unicode is used.
    Friend Declare Ansi Function MsgBox3 Lib "User32.dll" Alias "MessageBox" (
        ByVal hWnd As IntPtr, ByVal lpText As String, ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer
End Class
'</snippet5>

'<snippet6>
Public Class MsgBoxSample
    Public Shared Sub Main()
        NativeMethods.MsgBox(0, "Correct text", "MsgBox Sample", 0)
        NativeMethods.MsgBox2(0, "Incorrect text", "MsgBox Sample", 0)

        Try
            NativeMethods.MsgBox3(0, "No such function", "MsgBox Sample", 0)
        Catch e As EntryPointNotFoundException
            Console.WriteLine($"{NameOf(EntryPointNotFoundException)} thrown as expected!")
        End Try
    End Sub
End Class
'</snippet6>
'</snippet4>
