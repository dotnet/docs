private:
   void SetCell()
   {
      // Set the focus to the cell specified by the DataGridCell.
      DataGridCell dc;
      dc.RowNumber = 1;
      dc.ColumnNumber = 1;
      dataGrid1->CurrentCell = dc;
   }