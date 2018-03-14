' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      Dim s As String = "aaaaabbbcccccccdd"
      Dim charRange As Char = "b"c
      Dim startIndex As Integer = s.Indexof(charRange)
      Dim endIndex As Integer = s.LastIndexOf(charRange)
      Dim length = endIndex - startIndex + 1
      Console.WriteLine("{0}.Substring({1}, {2}) = {3}",
                        s, startIndex, length, 
                        s.Substring(startIndex, length))
   End Sub
End Module
' The example displays the following output:
'     aaaaabbbcccccccdd.Substring(5, 3) = bbb
' </Snippet2>
