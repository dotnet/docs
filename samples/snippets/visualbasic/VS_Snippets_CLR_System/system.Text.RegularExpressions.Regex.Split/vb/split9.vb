' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "plum-pear"
      Dim pattern As String = "(-)" 
      
      Dim substrings() As String = Regex.Split(input, pattern)    ' Split on hyphens.
      For Each match As String In substrings
         Console.WriteLine("'{0}'", match)
      Next
   End Sub
End Module
' The method writes the following to the console:
'    'plum'
'    '-'
'    'pear'      
' </Snippet9>

