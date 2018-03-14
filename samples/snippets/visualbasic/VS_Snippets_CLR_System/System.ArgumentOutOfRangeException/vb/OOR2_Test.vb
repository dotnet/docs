' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list() As String =  { "A", "B", "C" } 
      Try
        ' Display the last element of the list.
        Console.WriteLine(list(list.Length)) 
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine(e.Message)
      End Try
   End Sub
End Module
' The example displays the following output:
'   Index was out of range. Must be non-negative and less than the size of the collection.
'   Parameter name: index

