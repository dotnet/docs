Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Sub TestGetFieldType(ByVal reader As DataTableReader)
   For i As Integer = 0 To reader.FieldCount - 1
      Console.WriteLine(reader.GetName(i) & ":" & _
         reader.GetFieldType(i).FullName)
   Next
   Console.WriteLine("Press Enter to finish.")
   Console.ReadLine()
End Sub
' </Snippet1>
End Module


