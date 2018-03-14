' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim list As New List(Of String) 
      list.AddRange( { "A", "B", "C" } )
      ' <Snippet10>
      ' Display each element in the list.
      For Each item In list 
         Console.WriteLine("'{0}'", item) 
      Next   
      ' </Snippet10>
   End Sub
End Module
