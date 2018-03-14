' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is   text with   far  too   much   " + _
                            "whitespace."
      Dim pattern As String = "\s+"
      Dim replacement As String = " "
      Dim rgx As New Regex(pattern)
      Dim result As String = rgx.Replace(input, replacement)
      
      Console.WriteLine("Original String: {0}", input)
      Console.WriteLine("Replacement String: {0}", result)                             
   End Sub
End Module
' The example displays the following output:
'          Original String: This is   text with   far  too   much   whitespace.
'          Replacement String: This is text with far too much whitespace.
' </Snippet5>
