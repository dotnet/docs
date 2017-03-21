   void CreateNewDataGridColumnStyle()
   {
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      
      // Insert code to populate the DataSet.
      // Get the CurrencyManager for the table you want to add a column to.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Suppliers"]);
      
      // Get the PropertyDescriptor for the DataColumn.
      PropertyDescriptor^ pd = myCurrencyManager->GetItemProperties()[ "City" ];
      
      // Construct the DataGridColumnStyle with the PropertyDescriptor.
      DataGridColumnStyle^ myColumn = gcnew DataGridTextBoxColumn( pd );
      myColumn->MappingName = "City";
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->Add( myColumn );
   }
