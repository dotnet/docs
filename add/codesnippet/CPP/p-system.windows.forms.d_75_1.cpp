private:
   void SetCellWithFocus( DataGrid^ myGrid )
   {
      // Set the current cell to cell1, row 1.
      myGrid->CurrentCell = DataGridCell( 1, 1 );
   }

   void dataGrid1_GotFocus( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Console::WriteLine( "{0} {1}", dataGrid1->CurrentCell.ColumnNumber,
         dataGrid1->CurrentCell.RowNumber );
   }