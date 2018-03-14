' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list As New List(Of String)
      Console.WriteLine("Number of items: {0}", list.Count)
      Try
         Console.WriteLine("The first item: '{0}'", list(0))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'   Number of items: 0
'   Index was out of range. Must be non-negative and less than the size of the collection.
'   Parameter name: index
' </Snippet4>

Public Class Example2
   Public Sub Test
      Dim list As New List(Of String)
      Console.WriteLine("Number of items: {0}", list.Count)
      ' <Snippet5>
      If list.Count > 0 Then
         Console.WriteLine("The first item: '{0}'", list(0))
      End If
      ' </Snippet5>
   End Sub
End Class