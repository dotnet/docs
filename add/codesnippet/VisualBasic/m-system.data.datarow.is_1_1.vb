Private Sub IsValNull()
    ' Assuming the DataGrid is bound to a DataTable.
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim row As DataRow = table.Rows(datagrid1.CurrentCell.RowNumber)
    row.BeginEdit
    row(1) = System.DBNull.Value
    row.EndEdit
    row.AcceptChanges
    Console.WriteLine(row.IsNull(1))
End Sub