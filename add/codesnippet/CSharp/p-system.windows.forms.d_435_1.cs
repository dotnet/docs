private void GetSelectedIndex(DataGrid myGrid){
    Console.WriteLine(myGrid.CurrentRowIndex);
 }
 
 private void SetSelectedIndex(DataGrid myGrid, int selIndex){
    myGrid.CurrentRowIndex = selIndex;
 }
 