' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(-)|([|])"   ' possible delimiters found in string
      Dim input As String = "apple|apricot|plum|pear|pomegranate|pineapple|peach"

      Dim regex As Regex = New Regex(pattern)    
      ' Split on delimiters from 15th character on
      Dim substrings() As String = regex.Split(input, 4, 15)
      For Each match As String In substrings
         Console.WriteLine("'{0}'", match)
      Next
   End Sub
End Module
' In .NET 2.0, the method returns an array of
' 7 elements, as follows:
'    apple|apricot|plum'
'    '|'
'    'pear'
'    '|'
'    'pomegranate'
'    '|'
'    'pineapple|peach'
' In .NET 1.0 and 1.1, the method returns an array of
' 4 elements, as follows:
'    'apple|apricot|plum'
'    'pear'
'    'pomegranate'
'    'pineapple|peach'
' </Snippet7>

