private:
   void AddCustomColumnStyle()
   {
      // Set the TableStyle Mapping name.
      myTableStyle->MappingName = "customerTable";
      myTableStyle->BackColor = Color::Pink;
      
      // Set the ColumnStyle properties and add to TableStyle.
      myColumnStyle->MappingName = "Customers";
      myColumnStyle->HeaderText = "Customer Name";
      myColumnStyle->Width = 250;
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   void myButton1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the background color.
      myTableStyle->ResetBackColor();
   }