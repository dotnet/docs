private:
   void AlignmentChanged_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myMessage = "Alignment has been Changed";
   }

   void AddCustomDataTableStyle()
   {
      // Create a 'DataGridTableStyle'.
      DataGridTableStyle^ myDataTableStyle = gcnew DataGridTableStyle;
      myDataTableStyle->MappingName = "Customers";

      // Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      myDataGridColumnStyle->MappingName = "CustName";
      myDataGridColumnStyle->HeaderText = "Customer Name";
      myDataGridColumnStyle->Width = 250;
      myDataGridColumnStyle->AlignmentChanged += gcnew EventHandler( this, &Form1::AlignmentChanged_Click );

      // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );

      // Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid->TableStyles->Add( myDataTableStyle );
   }