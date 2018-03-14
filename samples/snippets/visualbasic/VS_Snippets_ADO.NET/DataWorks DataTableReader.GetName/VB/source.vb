Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Sub DisplayColumnNames(ByVal reader As DataTableReader)
   ' Given a DataTableReader, display column names.
   For i As Integer = 0 To reader.FieldCount - 1
      Console.WriteLine("{0}: {1}", i, reader.GetName(i))
   Next
End Sub
' </Snippet1>
End Module


