'<snippet4>
Imports System
Imports System.Runtime.InteropServices

'<snippet5>
Public Class LibWrap
   ' Declares managed prototypes for unmanaged functions.
   Declare Auto Function MsgBox Lib "User32.dll" Alias "MessageBox" ( _
       ByVal hWnd As Integer, ByVal txt As String, ByVal caption As String, _
       ByVal typ As Integer ) As Integer

   ' Causes incorrect output in the message window.
   Declare Ansi Function MsgBox2 Lib "User32.dll" Alias "MessageBoxW" ( _
       ByVal hWnd As Integer, ByVal txt As String, ByVal caption As String, _
       ByVal type As Integer ) As Integer

   ' Causes an exception to be thrown.
   ' ExactSpelling is True by default in when
   ' Ansi or Unicode is used.
   Declare Ansi Function MsgBox3 Lib "User32.dll" Alias "MessageBox" ( _
       ByVal hWnd As Integer, ByVal txt As String, ByVal caption As String, _
       ByVal typ As Integer ) As Integer
End Class
'</snippet5>

'<snippet6>
Public Class MsgBoxSample
    Public Shared Sub Main()
        LibWrap.MsgBox(0, "Correct text", "MsgBox Sample", 0)
        LibWrap.MsgBox2(0, "Incorrect text", "MsgBox Sample", 0)

        Try
            LibWrap.MsgBox3(0, "No such function", "MsgBox Sample", 0)
        Catch e As EntryPointNotFoundException
            Console.WriteLine("EntryPointNotFoundException thrown as expected!")
        End Try
    End Sub
End Class
'</snippet6>
'</snippet4>
