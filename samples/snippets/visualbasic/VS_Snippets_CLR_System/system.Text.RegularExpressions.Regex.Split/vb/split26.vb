' Visual Basic .NET Document
Option Strict On

' <Snippet26>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\d+"
      Dim rgx As New Regex(pattern)
      Dim input As String = "123ABCDE456FGHIJ789KLMNO012PQRST"
      Dim m As Match = rgx.Match(input)
      If m.Success Then 
         Dim startAt As Integer = m.Index
         Dim result() As String = rgx.Split(input, 3, startAt)
         For ctr As Integer = 0 To result.Length - 1
            Console.Write("'{0}'", result(ctr))
            If ctr < result.Length - 1 Then Console.Write(", ")
         Next
         Console.WriteLine()
      End If
   End Sub               
End Module
' The example displays the following output:
'       '', 'ABCDE', 'FGHIJKL789MNOPQ012'
' </Snippet26>
