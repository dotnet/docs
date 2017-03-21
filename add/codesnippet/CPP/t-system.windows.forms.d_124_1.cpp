private:
   void AddColumn()
   {
      DataTable^ myTable = gcnew DataTable;
      
      // Add a new DataColumn to the DataTable.
      DataColumn^ myColumn = gcnew DataColumn( "myTextBoxColumn" );
      myColumn->DataType = System::Type::GetType( "System::String" );
      myColumn->DefaultValue = "default string";
      myTable->Columns->Add( myColumn );
      
      // Get the CurrencyManager for the DataTable.
      CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(this->BindingContext[ myTable ]);
      
      // Use the CurrencyManager to get the PropertyDescriptor for the new column.
      System::ComponentModel::PropertyDescriptor^ pd = cm->GetItemProperties()[ "myTextBoxColumn" ];
      DataGridTextBoxColumn^ myColumnTextColumn;
      
      // Create the DataGridTextBoxColumn with the PropertyDescriptor.
      myColumnTextColumn = gcnew DataGridTextBoxColumn( pd );
      
      // Add the new DataGridColumn to the GridColumnsCollection.
      dataGrid1->DataSource = myTable;
      dataGrid1->TableStyles->Add( gcnew DataGridTableStyle );
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->Add( myColumnTextColumn );
   }
