Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Sub DisplayItems(ByVal reader As DataTableReader)
   Dim rowNumber As Integer
   While reader.Read()
      Console.WriteLine("Row " & rowNumber)
      For i As Integer = 0 To reader.FieldCount - 1
         Console.WriteLine("{0}: {1}", reader.GetName(i), reader.Item(i))
      Next
      rowNumber += 1
   End While
End Sub
' </Snippet1>
End Module


