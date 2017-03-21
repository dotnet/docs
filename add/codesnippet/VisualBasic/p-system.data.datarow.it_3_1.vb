Private Sub DataGrid1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)
    
    Dim dataGridTable As DataTable = _
        CType(DataGrid1.DataSource, DataTable)
    ' Set the current row using the RowNumber 
    ' property of the CurrentCell.
    Dim currentRow As DataRow = _
        dataGridTable.Rows(DataGrid1.CurrentCell.RowNumber)
    Dim column As DataColumn = dataGridTable.Columns(1)

    ' Get the value of the column 1 in the DataTable.
    label1.Text = currentRow(column).ToString()
End Sub
 
Private Sub SetDataRowValue( _
    ByVal grid As DataGrid, ByVal newVal As Object)

    ' Set the value of a column in the last row of a DataGrid.
    Dim table As DataTable = CType(grid.DataSource, DataTable)
    Dim row As DataRow = table.Rows(table.Rows.Count - 1)
    Dim column As DataColumn = table.Columns("FirstName")
    row(column)= newVal
End Sub