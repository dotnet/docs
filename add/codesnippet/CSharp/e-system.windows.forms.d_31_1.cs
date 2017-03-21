   // Create an instance of the 'CurrentCellChanged' EventHandler.
   private void CallCurrentCellChanged()
   {
      myDataGrid.CurrentCellChanged += new EventHandler(Grid_CurCellChange);
   }

   // Raise the event when focus on DataGrid cell changes.
   private void Grid_CurCellChange(object sender, EventArgs e)
   {
      // String variable used to show message.
      string myString = "CurrentCellChanged event raised, cell focus is at ";
      // Get the co-ordinates of the focussed cell.
      string myPoint  = myDataGrid.CurrentCell.ColumnNumber + "," +
                     myDataGrid.CurrentCell.RowNumber;
      // Create the alert message.
      myString = myString + "(" + myPoint + ")";
      // Show Co-ordinates when CurrentCellChanged event is raised.
      MessageBox.Show(myString, "Current cell co-ordinates");
   }