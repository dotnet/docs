private:
   void myButton1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Set the 'HeaderForeColor' property.
      myDataTableStyle->HeaderForeColor = Color::Blue;
   }

   void myButton2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'HeaderForeColor' property to its default value.
      myDataTableStyle->ResetHeaderForeColor();
   }