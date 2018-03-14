' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "a*"
      Dim input As String = "abaabb"
      
      Dim m As Match = Regex.Match(input, pattern)
      Do While m.Success
         Console.WriteLine("'{0}' found at index {1}.", 
                           m.Value, m.Index)
         m = m.NextMatch()
      Loop         
   End Sub
End Module
' The example displays the following output:
'       'a' found at index 0.
'       '' found at index 1.
'       'aa' found at index 2.
'       '' found at index 4.
'       '' found at index 5.
'       '' found at index 6.
' </Snippet1>

