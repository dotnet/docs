protected void TextExpanded(DataGrid myGrid){
    // Get the DataTable of the grid
    DataTable myTable;
    // Assuming the grid is bound to a DataTable
    myTable = (DataTable) myGrid.DataSource;
    for(int i = 0;i < myTable.Rows.Count ;i++) {
       if(myGrid.IsExpanded(i)) {
          Console.WriteLine("Row " + i + " was expanded");
       }
    }
 }
    