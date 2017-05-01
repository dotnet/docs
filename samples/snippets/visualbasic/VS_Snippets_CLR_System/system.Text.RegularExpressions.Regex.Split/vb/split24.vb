' Visual Basic .NET Document
Option Strict On

' <Snippet24>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "[a-z]+"
      Dim input As String = "Abc1234Def5678Ghi9012Jklm"
      Dim result() As String = Regex.Split(input, pattern, 
                                           RegexOptions.IgnoreCase)
      For ctr As Integer = 0 To result.Length - 1
         Console.Write("'{0}'", result(ctr))
         If ctr < result.Length - 1 Then Console.Write(", ")
      Next
      Console.WriteLine()
   End Sub               
End Module
' The example displays the following output:
'       '', '1234', '5678', '9012', ''
' </Snippet24>
