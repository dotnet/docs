imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub DataGrid1_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' Get the DataTable the grid is bound to.
    Dim thisGrid As DataGrid = CType(sender, DataGrid)
    Dim table As DataTable = CType(thisGrid.DataSource, DataTable)
    Dim currentRow As DataRow = _
        table.Rows(thisGrid.CurrentCell.RowNumber)

    ' Get the value of the column 1 in the DataTable.
    Console.WriteLine(currentRow(1))
    ' You can also use the name of the column:
    ' Console.WriteLine(currentRow("FirstName"))
    End Sub

    Private Sub SetDataRowValue( _
        ByVal grid As DataGrid, ByVal newValue As Object)

    ' Set the value of the last column in the last row of a DataGrid.
    Dim table As DataTable
    table = CType(grid.DataSource, DataTable)
    Dim row As DataRow 
    row = table.Rows(table.Rows.Count-1)
    row(table.Columns.Count-1) = newValue
End Sub
' </Snippet1>

End Class
