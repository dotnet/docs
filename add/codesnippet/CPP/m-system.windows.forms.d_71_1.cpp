private:
   void myButton1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //Set the 'AlternatingBackColor'.
      myDataGridTableStyle->AlternatingBackColor = Color::Blue;
   }

   void myButton2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'AlternatingBackColor'.
      myDataGridTableStyle->ResetAlternatingBackColor();
   }