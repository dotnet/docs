private:
   void AddColumn( DataTable^ myTable )
   {
      // Add a new DataColumn to the DataTable.
      DataColumn^ myColumn = gcnew DataColumn( "myTextBoxColumn" );
      myColumn->DataType = String::typeid;
      myColumn->DefaultValue = "default string";
      myTable->Columns->Add( myColumn );

      // Get the ListManager for the DataTable.
      CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(this->BindingContext[ myTable ]);

      // Use the ListManager to get the PropertyDescriptor for the new column.
      PropertyDescriptor^ pd = cm->GetItemProperties()[ "myTextBoxColumn" ];

      // Create a new DataTimeFormat object.
      DateTimeFormatInfo^ fmt = gcnew DateTimeFormatInfo;

      // Insert code to set format.
      DataGridTextBoxColumn^ myColumnTextColumn;

      // Create the DataGridTextBoxColumn with the PropertyDescriptor and Format.
      myColumnTextColumn = gcnew DataGridTextBoxColumn( pd,fmt->SortableDateTimePattern );

      // Add the new DataGridColumnStyle to the GridColumnsCollection.
      dataGrid1->TableStyles[ 0 ]->GridColumnStyles->Add( myColumnTextColumn );
   }