private:
   void MySetButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Set the 'HeaderFont' property of the DataGridTableStyle instance.
      myTableStyle->HeaderFont = gcnew System::Drawing::Font( "Impact",10 );

      // Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   void MyResetButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the Header Font to its default value.
      myTableStyle->ResetHeaderFont();
   }