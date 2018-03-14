' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "plum--pear"
      Dim pattern As String = "-"          ' Split on hyphens
      
      Dim substrings() As String = Regex.Split(input, pattern)
      For Each match As String In substrings
         Console.WriteLine("'{0}'", match)
      Next
   End Sub  
End Module
' The example displays the following output:
'    'plum'
'    ''
'    'pear'      
' </Snippet8>

