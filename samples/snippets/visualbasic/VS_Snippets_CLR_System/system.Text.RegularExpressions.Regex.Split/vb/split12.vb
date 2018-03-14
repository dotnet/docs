' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "characters"
      Dim regex As New Regex("")
      Dim substrings() As String = regex.Split(input, input.Length)
      Console.Write("{")
      For ctr As Integer = 0 to substrings.Length - 1
         Console.Write(substrings(ctr))
         if ctr < substrings.Length - 1 Then Console.Write(", ")
      Next
      Console.WriteLine("}")
   End Sub
End Module
' The example displays the following output:   
'    {, c, h, a, r, a, c, t, e, rs}
' </Snippet12>

