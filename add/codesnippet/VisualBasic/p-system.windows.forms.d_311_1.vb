Private Sub PrintCell(sender As Object, e As MouseEventArgs)
   Dim thisGrid As DataGrid = CType(sender, DataGrid)
   Dim myDataGridCell As DataGridCell = thisGrid.CurrentCell
   Dim bm As BindingManagerBase = _
   BindingContext (thisGrid.DataSource, thisGrid.DataMember)
   Dim drv As DataRowView = CType(bm.Current, DataRowView)
   Console.WriteLine(drv(myDataGridCell.ColumnNumber))
   Console.WriteLine(myDataGridCell.RowNumber)
End Sub
