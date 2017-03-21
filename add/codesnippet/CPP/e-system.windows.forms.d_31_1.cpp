   // Create an instance of the 'CurrentCellChanged' EventHandler.
private:
   void CallCurrentCellChanged()
   {
      myDataGrid->CurrentCellChanged += gcnew EventHandler( this, &MyDataGrid::Grid_CurCellChange );
   }

   // Raise the event when focus on DataGrid cell changes.
   void Grid_CurCellChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "CurrentCellChanged event raised, cell focus is at ";

      // Get the co-ordinates of the focussed cell.
      String^ myPoint = String::Concat( myDataGrid->CurrentCell.ColumnNumber, ", ", myDataGrid->CurrentCell.RowNumber );

      // Create the alert message.
      myString = String::Concat( myString, "(", myPoint, ")" );

      // Show Co-ordinates when CurrentCellChanged event is raised.
      MessageBox::Show( myString, "Current cell co-ordinates" );
   }