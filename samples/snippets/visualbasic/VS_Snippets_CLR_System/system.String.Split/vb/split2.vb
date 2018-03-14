' <Snippet2>
Public Class SplitTest
    Public Shared Sub Main()
        Dim words As String = "This is a list of words, with: a bit of punctuation" + _
                              vbTab + "and a tab character."
        Dim split As String() = words.Split(New [Char]() {" "c, ","c, "."c, ":"c, CChar(vbTab) })
                
        For Each s As String In  split
            If s.Trim() <> "" Then
                Console.WriteLine(s)
            End If
        Next s
    End Sub 'Main
End Class 'SplitTest
' The example displays the following output to the console:
'       This
'       is
'       a
'       list
'       of
'       words
'       with
'       a
'       bit
'       of
'       punctuation
'       and
'       a
'       tab
'       character
' </Snippet2>
