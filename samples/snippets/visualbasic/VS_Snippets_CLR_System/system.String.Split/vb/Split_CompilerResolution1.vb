' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Module Example
   Public Sub Main()
      Dim value As String = "This is a short string."
      Dim delimiter As Char = "s"c
      Dim substrings() As String = value.Split(delimiter)
      For Each substring In substrings
         Console.WriteLine(substring)
      Next
   End Sub
End Module
' The example displays the following output:
'     Thi
'      i
'      a
'     hort
'     tring.
' </Snippet12>
