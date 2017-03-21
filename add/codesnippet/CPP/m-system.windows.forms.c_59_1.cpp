private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Takes the selected text from a text box and puts it on the clipboard.
      if ( !textBox1->SelectedText->Equals( "" ) )
      {
         Clipboard::SetDataObject( textBox1->SelectedText, true );
      }
      else
      {
         textBox2->Text = "No text selected in textBox1";
      }
   }