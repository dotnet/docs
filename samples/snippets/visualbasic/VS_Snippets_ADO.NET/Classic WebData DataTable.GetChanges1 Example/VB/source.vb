Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
Private Sub ProcessDeletes(table As DataTable, _
    adapter As OleDbDataAdapter)

   Dim changeTable As DataTable = table.GetChanges(DataRowState.Deleted)

   ' Check the DataTable for errors.
   If table.HasErrors Then
      ' Insert code to resolve errors.
   End If

   ' After fixing errors, update the database with the DataAdapter 
   adapter.Update(changeTable)
End Sub
' </Snippet1>
End Class