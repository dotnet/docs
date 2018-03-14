' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\d+"
      Dim input As String = "123ABCDE456FGHIJKL789MNOPQ012"
      Dim result() As String = Regex.Split(input, pattern)
      For ctr As Integer = 0 To result.Length - 1
         Console.Write("'{0}'", result(ctr))
         If ctr < result.Length - 1 Then Console.Write(", ")
      Next
      Console.WriteLine()
   End Sub               
End Module
' The example displays the following output:
'       '', 'ABCDE', 'FGHIJKL', 'MNOPQ', ''
' </Snippet22>
