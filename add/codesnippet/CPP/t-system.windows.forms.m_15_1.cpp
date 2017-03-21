private:
   void richTextBox1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determine which mouse button is clicked.
      if ( e->Button == ::MouseButtons::Left )
      {
         // Obtain the character at which the mouse cursor was clicked at.
         Char tempChar = richTextBox1->GetCharFromPosition( Point(e->X,e->Y) );

         // Determine whether the character is an empty space.
         if (  !tempChar.ToString()->Equals( " " ) )

         // Display the character in a message box.
         MessageBox::Show( String::Format( "The character at the specified position is {0}.", tempChar ) );
      }
   }