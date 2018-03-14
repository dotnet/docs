' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "07/14/2007"   
      Dim pattern As String = "(-)|(/)"
      For Each result As String In Regex.Split(input, pattern) 
         Console.WriteLine("'{0}'", result)
      Next
   End Sub
End Module
' In .NET 1.0 and 1.1, the method returns an array of
' 3 elements, as follows:
'    '07'
'    '14'
'    '2007'
'
' In .NET 2.0 and later, the method returns an array of
' 5 elements, as follows:
'    '07'
'    '/'
'    '14'
'    '/'
'    '2007' 
' </Snippet10>     

