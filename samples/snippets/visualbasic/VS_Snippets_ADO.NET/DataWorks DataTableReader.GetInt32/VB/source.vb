Option Explicit
Option Strict

Imports System
Imports System.Data
Module Module1

   Sub Main()

   End Sub
    
' <Snippet1>
Private Sub PrintColumn(ByVal reader As DataTableReader)
   ' Loop through all the rows in the DataTableReader
   While reader.Read()
      If reader.IsDBNull(2) Then
         Console.Write("<NULL>")
      Else
         Try
            Console.Write(reader.GetInt32(2))
         Catch ex As InvalidCastException
            Console.Write("Invalid data type.")
         End Try
      End If
      Console.WriteLine()
   End While
End Sub
' </Snippet1>
End Module


