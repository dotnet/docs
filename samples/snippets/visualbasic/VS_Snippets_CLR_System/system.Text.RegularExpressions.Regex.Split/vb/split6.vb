' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(-)"
      Dim input As String = "apple-apricot-plum-pear-pomegranate-pineapple-peach"

      Dim regex As Regex = New Regex(pattern)    
      ' Split on hyphens from 15th character on
      Dim substrings() As String = regex.Split(input, 4, 15)
      For Each match As String In substrings
         Console.WriteLine("'{0}'", match)
      Next
   End Sub  
End Module
' The example displays the following output:
'    'apple-apricot-plum'
'    '-'
'    'pear'
'    '-'
'    'pomegranate'
'    '-'
'    'pineapple-peach'      
' </Snippet6>

