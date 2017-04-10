' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module Example
   Public Sub Main()
      Dim value As String = "This is a string."
      Dim startIndex As Integer = 5
      Dim length As Integer = 2
      Dim substring As String = value.Substring(startIndex, length)
      Console.WriteLine(substring)
   End Sub
End Module
' The example displays the following output:
'       is
' </Snippet4>

