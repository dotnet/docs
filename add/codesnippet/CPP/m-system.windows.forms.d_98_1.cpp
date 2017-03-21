   void AddDataGridBoolColumnStyle()
   {
      DataGridBoolColumn^ myColumn = gcnew DataGridBoolColumn;
      myColumn->MappingName = "Current";
      myColumn->Width = 200;
      dataGrid1->TableStyles[ "Customers" ]->GridColumnStyles->Add( myColumn );
   }
