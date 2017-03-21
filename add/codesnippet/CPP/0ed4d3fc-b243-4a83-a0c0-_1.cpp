private:
   void MyAddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet'.
      CurrencyManager^ myCurrencyManger = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet ]);
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      myTableStyle->MappingName = "Customers";
      PropertyDescriptor^ proprtyDescriptorName = myCurrencyManger->GetItemProperties()[ "CustName" ];
      DataGridColumnStyle^ myCustomerNameStyle = gcnew DataGridTextBoxColumn( proprtyDescriptorName );
      myCustomerNameStyle->MappingName = "custName";
      myCustomerNameStyle->HeaderText = "Customer Name";
      myTableStyle->GridColumnStyles->Add( myCustomerNameStyle );

      // Add style for 'Date' column.
      PropertyDescriptor^ myDateDescriptor = myCurrencyManger->GetItemProperties()[ "Date" ];

      // 'G' is for MM/dd/yyyy HH:mm:ss date format.
      DataGridColumnStyle^ myDateStyle = gcnew DataGridTextBoxColumn( myDateDescriptor,"G" );
      myDateStyle->MappingName = "Date";
      myDateStyle->HeaderText = "Date";
      myDateStyle->Width = 150;
      myTableStyle->GridColumnStyles->Add( myDateStyle );

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
   }