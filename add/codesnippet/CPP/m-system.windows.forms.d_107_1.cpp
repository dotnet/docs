protected:
   DataGridCell dgc;

   void GetRect()
   {
      Rectangle rect;
      dgc.ColumnNumber = 0;
      dgc.RowNumber = 0;
      rect = dataGrid1->GetCellBounds( dgc );
      Console::WriteLine( rect );
   }