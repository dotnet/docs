Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
    
    
' <Snippet1>
Private Sub DemonstrateRowNotInTableException()
    ' Create a DataTable with one column and ten rows.      
    Dim table As New DataTable("NewTable")
    Dim column As New DataColumn("NewColumn")
    table.Columns.Add(column)

    Dim newRow As DataRow
    Dim i As Integer
    For i = 0 To 9
        newRow = table.NewRow()
        newRow("NewColumn") = i
        table.Rows.Add(newRow)
    Next i

    Try
        ' Remove a row and invoke AcceptChanges.
        Dim removedRow As DataRow = table.Rows(9)
        removedRow.Delete()
        removedRow.AcceptChanges()
    
    Catch rowException As System.Data.RowNotInTableException
        Console.WriteLine("Row not in table")
    End Try
End Sub 
' </Snippet1>
End Class 'Form1 
