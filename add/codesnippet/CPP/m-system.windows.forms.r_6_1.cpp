private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      array<Char>^temp1 = {'D','e','l','t','a'};
      MessageBox::Show( FindMyText( temp1 ).ToString() );
   }

public:
   int FindMyText( array<Char>^text )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;

      // Ensure that a search string has been specified and a valid start point.
      if ( text->Length > 0 )
      {
         // Obtain the location of the first character found in the control
         // that matches any of the characters in the char array.
         int indexToText = richTextBox1->Find( text );

         // Determine whether the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            // Return the location of the character.
            returnValue = indexToText;
         }
      }

      return returnValue;
   }