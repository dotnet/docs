private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Change the color of 'HeaderBack'.
      myDataTableStyle->HeaderBackColor = Color::LightPink;
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'HeaderBack' to its origanal color.
      myDataTableStyle->ResetHeaderBackColor();
   }