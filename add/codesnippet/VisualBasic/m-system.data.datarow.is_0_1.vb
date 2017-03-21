 Private Sub IsValNull()
    ' Assuming the DataGrid is bound to a DataTable.
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim row As DataRow = table.Rows(datagrid1.CurrentCell.RowNumber)
    row.BeginEdit
    row("FirstName") = System.DBNull.Value
    row.EndEdit
    row.AcceptChanges
    Console.WriteLine(row.IsNull("FirstName"))
End Sub