private:
   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      
      // Map DataGridTableStyle to a DataTable.
      myTableStyle->MappingName = "Orders";
      
      // Get CurrencyManager Object*.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[myDataSet, "Orders"]);
      
      // Use the CurrencyManager to get the PropertyDescriptor for the column.
      PropertyDescriptor^ myPropertyDescriptor = myCurrencyManager->GetItemProperties()[ "Amount" ];
      
      // Change the HeaderText.
      DataGridColumnStyle^ myColumnStyle = gcnew DataGridTextBoxColumn( myPropertyDescriptor,"c",true );
      
      // Attach a event handler function with the 'HeaderTextChanged' event.
      myColumnStyle->HeaderTextChanged += gcnew EventHandler( this, &myDataForm::MyHeaderText_Changed );
      myColumnStyle->Width = 130;
      myColumnStyle->HeaderText = "Amount in $";
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
      TablesAlreadyAdded = (bool *)true;
   }

   void MyHeaderText_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myLabel->Text = "Header Descriptor Property of DataGridColumnStyle has changed";
   }