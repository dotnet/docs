private void PrintCell(object sender, MouseEventArgs e)
{
   DataGrid thisGrid = (DataGrid) sender;
   DataGridCell myDataGridCell = thisGrid.CurrentCell;
   BindingManagerBase bm = BindingContext[thisGrid.DataSource, thisGrid.DataMember];
   DataRowView drv = (DataRowView) bm.Current;
   Console.WriteLine(drv [myDataGridCell.ColumnNumber]);
   Console.WriteLine(myDataGridCell.RowNumber);
}
