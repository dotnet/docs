' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Collections.Generic
Imports System.Linq

Module Func
   Public Sub Main()
      ' Declare a Func variable and assign a lambda expression to the  
      ' variable. The method takes a string and converts it to uppercase.
      Dim selector As Func(Of String, String) = Function(str) str.ToUpper()
   
      ' Create an array of strings.
      Dim words() As String = { "orange", "apple", "Article", "elephant" }
      ' Query the array and select strings according to the selector method.
      Dim aWords As IEnumerable(Of String) = words.Select(selector)
   
      ' Output the results to the console.
      For Each word As String In aWords
         Console.WriteLine(word)
      Next
   End Sub
End Module
' This code example produces the following output:
'           
'   ORANGE
'   APPLE
'   ARTICLE
'   ELEPHANT
' </Snippet5>

