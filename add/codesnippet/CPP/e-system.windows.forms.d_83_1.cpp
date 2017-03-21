private:
   void AddCustomColumnStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      myTableStyle->MappingName = "Orders";
      myColumnStyle = gcnew DataGridTextBoxColumn;
      myColumnStyle->MappingName = "Orders";
      myColumnStyle->HeaderText = "Orders";
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
      myColumnStyle->MappingNameChanged += gcnew EventHandler( this, &MyForm::columnStyle_MappingNameChanged );
      flag = (bool *)true;
   }

   // MappingNameChanged event handler of DataGridColumnStyle.
   void columnStyle_MappingNameChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Mapping Name changed" );
   }