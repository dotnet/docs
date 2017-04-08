' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Collections.Generic
Imports System.Linq

Public Module Func3Example

   Public Sub Main()
      Dim predicate As Func(Of String, Integer, Boolean) = Function(str, index) str.Length = index

      Dim words() As String = { "orange", "apple", "Article", "elephant", "star", "and" }
      Dim aWords As IEnumerable(Of String) = words.Where(predicate)

      For Each word As String In aWords
         Console.WriteLine(word)
      Next   
   End Sub
End Module
' </Snippet5>
