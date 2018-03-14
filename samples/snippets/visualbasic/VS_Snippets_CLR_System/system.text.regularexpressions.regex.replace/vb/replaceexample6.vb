' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "This is   text with   far  too   much   " + _
                            "whitespace."
      Dim pattern As String = "\s+"
      Dim replacement As String = " "
      Dim result As String = Regex.Replace(input, pattern, replacement)
      
      Console.WriteLine("Original String: {0}", input)
      Console.WriteLine("Replacement String: {0}", result)                             
   End Sub
End Module
' The example displays the following output:
'          Original String: This is   text with   far  too   much   whitespace.
'          Replacement String: This is text with far too much whitespace.
' </Snippet6>
