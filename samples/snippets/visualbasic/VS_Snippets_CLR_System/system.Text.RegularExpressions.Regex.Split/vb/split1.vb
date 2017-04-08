' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module RegexSplit
   Public Sub Main()
      Dim regex As Regex = New Regex("-")         ' Split on hyphens.
      Dim substrings() As String = regex.Split("plum--pear")
      For Each match As String In substrings
         Console.WriteLine("'{0}'", match)
      Next
   End Sub
End Module
' The example displays the following output:
'    'plum'
'    ''
'    'pear'      
' </Snippet1>

