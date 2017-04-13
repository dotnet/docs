' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text.RegularExpressions

Module Main
   Public Sub Main()
      Dim input As String = "characters"
      Dim regex As New Regex("")
      Dim substrings() As String = regex.Split(input)
      Console.Write("{")
      For ctr As Integer = 0 to substrings.Length - 1
         Console.Write(substrings(ctr))
         If ctr < substrings.Length - 1 Then Console.Write(", ")
      Next
      Console.WriteLine("}")
   End Sub
End Module
' The example produces the following output:   
'    {, c, h, a, r, a, c, t, e, r, s, }
' </Snippet11>

