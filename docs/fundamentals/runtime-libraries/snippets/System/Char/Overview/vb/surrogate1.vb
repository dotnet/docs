' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO

Module Example4
    Public Sub Main()
        Dim sw As New StreamWriter(".\chars2.txt")
        Dim utf32 As Integer = &H1D160
        Dim surrogate As String = Char.ConvertFromUtf32(utf32)
        sw.WriteLine("U+{0:X6} UTF-32 = {1} ({2}) UTF-16",
                   utf32, surrogate, ShowCodePoints(surrogate))
        sw.Close()
    End Sub

    Private Function ShowCodePoints(value As String) As String
        Dim retval As String = Nothing
        For Each ch In value
            retval += String.Format("U+{0:X4} ", Convert.ToUInt16(ch))
        Next
        Return retval.Trim()
    End Function
End Module
' The example produces the following output:
'       U+01D160 UTF-32 = ð (U+D834 U+DD60) UTF-16
' </Snippet2>
