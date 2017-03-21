private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      array<Char>^temp0 = {'B','r','a','v','o'};
      MessageBox::Show( FindMyText( temp0, 5 ).ToString() );
   }

public:
   int FindMyText( array<Char>^text, int start )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;

      // Ensure that a valid char array has been specified and a valid start point.
      if ( text->Length > 0 && start >= 0 )
      {
         // Obtain the location of the first character found in the control
         // that matches any of the characters in the char array.
         int indexToText = richTextBox1->Find( text, start );

         // Determine whether any of the chars are found in richTextBox1.
         if ( indexToText >= 0 )
         {
            // Return the location of the character.
            returnValue = indexToText;
         }
      }

      return returnValue;
   }