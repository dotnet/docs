private:
   // Set the header font to Arial with size 20.
   void button6_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->HeaderFont = gcnew System::Drawing::Font( "Arial",20 );
   }

   // Reset the header font.
   void button5_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->ResetHeaderFont();
   }