   void SetReadOnly()
   {
      DataColumnCollection^ myDataColumns;
      
      // Get the columns for a table bound to a DataGrid.
      myDataColumns = dataSet1->Tables[ "Suppliers" ]->Columns;
      System::Collections::IEnumerator^ myEnum = myDataColumns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataColumn^ dataColumn = safe_cast<DataColumn^>(myEnum->Current);
         dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ dataColumn->ColumnName ]->ReadOnly = dataColumn->ReadOnly;
      }
   }
