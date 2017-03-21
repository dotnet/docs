private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myButton->Text->Equals( "Make column read/write" ) )
      {
         myDataGridColumnStyle->ReadOnly = false;
         myButton->Text = "Make column read only";
      }
      else
      {
         myDataGridColumnStyle->ReadOnly = true;
         myButton->Text = "Make column read/write";
      }
   }

   void AddCustomDataTableStyle()
   {
      myDataGridTableStyle = gcnew DataGridTableStyle;
      myDataGridTableStyle->MappingName = "Customers";
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      myDataGridColumnStyle->MappingName = "CustName";
      
      // Add EventHandler function for readonlychanged event.
      myDataGridColumnStyle->ReadOnlyChanged += gcnew EventHandler( this, &MyForm1::myDataGridColumnStyle_ReadOnlyChanged );
      myDataGridColumnStyle->HeaderText = "Customer";
      myDataGridTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );
      
      // Add the 'DataGridTableStyle' instance to the 'DataGrid'.
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
   }

   void myDataGridColumnStyle_ReadOnlyChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "'Readonly' property is changed" );
   }