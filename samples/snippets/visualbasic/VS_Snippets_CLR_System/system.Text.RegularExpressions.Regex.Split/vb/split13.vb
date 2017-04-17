' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "characters"
      Dim substrings() As String = Regex.Split(input, "")
      Console.Write("{")
      For ctr As Integer = 0 to substrings.Length - 1
         Console.Write("'{0}'", substrings(ctr))
         If ctr < substrings.Length - 1 Then Console.Write(", ")
      Next
      Console.WriteLine("}")
   End Sub
End Module
' The example produces the following output:   
'    {'', 'c', 'h', 'a', 'r', 'a', 'c', 't', 'e', 'r', 's', ''}
' </Snippet13>

