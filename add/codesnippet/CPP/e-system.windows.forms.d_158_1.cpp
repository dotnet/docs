private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( TablesAlreadyAdded )
      {
         return;
      }

      AddCustomDataTableStyle();
   }

   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      
      // Map DataGridTableStyle to a DataTable.
      myTableStyle->MappingName = "Orders";
      
      // Get CurrencyManager object.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[myDataSet, "Orders"]);
      
      // Use the CurrencyManager to get the PropertyDescriptor for column.
      PropertyDescriptor^ myPropertyDescriptor = myCurrencyManager->GetItemProperties()[ "Amount" ];
      
      // Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
      DataGridColumnStyle^ myColumnStyle = gcnew DataGridTextBoxColumn( myPropertyDescriptor,"c",true );
      
      // Add EventHandler function for PropertyDescriptorChanged Event.
      myColumnStyle->PropertyDescriptorChanged += gcnew System::EventHandler( this, &myDataForm::MyPropertyDescriptor_Changed );
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      
      // Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
      TablesAlreadyAdded = true;
   }

   void MyPropertyDescriptor_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myLabel->Text = "Property Descriptor Property of DataGridColumnStyle has changed";
   }