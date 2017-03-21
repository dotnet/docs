private void SetCellWithFocus(DataGrid myGrid)
 {
    // Set the current cell to cell1, row 1.
    myGrid.CurrentCell = new DataGridCell(1,1);
 }
 
 private void dataGrid1_GotFocus(object sender, EventArgs e)
 {
    Console.WriteLine(dataGrid1.CurrentCell.ColumnNumber + 
    " " + dataGrid1.CurrentCell.RowNumber);
 }
    