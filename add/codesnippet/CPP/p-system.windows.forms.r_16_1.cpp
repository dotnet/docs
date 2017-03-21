private:
   void AddMyText( String^ textToAdd )
   {
      // Determine if the text to add is larger than the max length property.
      if ( textToAdd->Length > richTextBox1->MaxLength )
         // Alert user text is too large.
         MessageBox::Show( "The text is too large to add to the RichTextBox" ); // Add the text to be added to the control.
      else
         richTextBox1->SelectedText = textToAdd;
   }