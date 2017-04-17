Imports System
Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
Private Sub UpdateDataTable(table As DataTable, _
    myDataAdapter As OleDbDataAdapter)

    Dim xDataTable As DataTable = table.GetChanges()

    ' Check the DataTable for errors.
    If xDataTable.HasErrors Then
        ' Insert code to resolve errors.
    End If

    ' After fixing errors, update the database with the DataAdapter 
    myDataAdapter.Update(xDataTable)
End Sub
' </Snippet1>
End Class