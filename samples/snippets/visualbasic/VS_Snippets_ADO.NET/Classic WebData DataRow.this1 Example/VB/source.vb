Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    
' <Snippet1>
Private Sub DataGrid1_Click( _
    sender As Object, e As System.EventArgs)
     
    ' Get the DataTable the grid is bound to.
    Dim thisGrid As DataGrid = CType(sender, DataGrid)
    Dim table As DataTable = _
        CType(thisGrid.DataSource, DataTable)
    Dim currentRow As DataRow = _
        table.Rows(thisGrid.CurrentCell.RowNumber)

    ' Get the value of the column 1 in the DataTable.
    Console.WriteLine(currentRow("FirstName"))
    ' You can also use the index:
    ' Console.WriteLine(currentRow(1).ToString())
End Sub
    
Private Sub SetDataRowValue( _
    grid As DataGrid, newValue As Object)
    ' Set the value of the first column in 
    ' the last row of a DataGrid.
    Dim table As DataTable = _
        CType(grid.DataSource, DataTable)
    Dim row As DataRow
    row = table.Rows((table.Rows.Count - 1))
    row("FirstName") = newValue
End Sub
' </Snippet1>
End Class
