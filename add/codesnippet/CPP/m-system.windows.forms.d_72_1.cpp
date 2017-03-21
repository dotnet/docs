private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Change the 'GridLineColor'.
      myDataTableStyle->GridLineColor = Color::Blue;
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'GridLineColor' to its orginal color.
      myDataTableStyle->ResetGridLineColor();
   }