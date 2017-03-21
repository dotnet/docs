Private Sub DataGrid1_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs)
    
    ' Set the current row using the RowNumber property of the CurrentCell.
    Dim currentRow As DataRow = CType(DataGrid1.DataSource, DataTable). _
       Rows(DataGrid1.CurrentCell.RowNumber)

    ' Get the value of the column 1 in the DataTable.
    label1.Text = currentRow(1, DataRowVersion.Current).ToString()
End Sub