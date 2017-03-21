
 Private dataTable As DataTable
 
 Private Sub [AddHandler]()
    dataTable = CType(DataGrid1.DataSource, DataTable)
    AddHandler dataTable.RowChanged, AddressOf Me.dataTable_Changed
 End Sub
 
 Private Sub dataTable_Changed _
 (ByVal sender As System.Object, ByVal e As System.Data.DataRowChangeEventArgs)
    Console.WriteLine("Row Changed", e.Action, e.Row.Item(DataGrid1.CurrentCell.ColumnNumber))
 End Sub