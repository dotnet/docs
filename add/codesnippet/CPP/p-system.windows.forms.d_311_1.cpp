   void PrintCell( Object^ sender, MouseEventArgs^ /*e*/ )
   {
      DataGrid^ thisGrid = dynamic_cast<DataGrid^>(sender);
      DataGridCell myDataGridCell = thisGrid->CurrentCell;
      BindingManagerBase^ bm = BindingContext[ thisGrid->DataSource,thisGrid->DataMember ];
      DataRowView^ drv = dynamic_cast<DataRowView^>(bm->Current);
      Console::WriteLine( drv[ myDataGridCell.ColumnNumber ] );
      Console::WriteLine( myDataGridCell.RowNumber );
   }
