Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Sub GetAllValues(ByVal reader As DataTableReader)

   ' Given a DataTableReader, retrieve the value of 
   ' each column, and display the name, value, and type.
   ' Make sure you've called reader.Read at least once before
   ' calling this procedure.
   ' Loop through all the columns.
   Dim value As Object
   For i As Integer = 0 To reader.FieldCount - 1
      If reader.IsDBNull(i) Then
         value = "<NULL>"
      Else
         value = reader.GetValue(i)
      End If
      Console.WriteLine("{0}: {1} ({2})", reader.GetName(i), _
         value, reader.GetFieldType(i).Name)
   Next
End Sub
' </Snippet1>
End Module


