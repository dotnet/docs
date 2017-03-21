private:
   void textBox1_Enter( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // If the TextBox contains text, change its foreground and background colors.
      if ( textBox1->Text != String::Empty )
      {
         textBox1->ForeColor = Color::Red;
         textBox1->BackColor = Color::Black;

         // Move the selection pointer to the end of the text of the control.
         textBox1->Select(textBox1->Text->Length,0);
      }
   }

   void textBox1_Leave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Reset the colors and selection of the TextBox after focus is lost.
      textBox1->ForeColor = Color::Black;
      textBox1->BackColor = Color::White;
      textBox1->Select(0,0);
   }