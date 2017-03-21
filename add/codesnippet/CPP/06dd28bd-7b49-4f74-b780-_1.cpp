public:
   int FindMyText( String^ text, int start )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;
      
      // Ensure that a search string has been specified and a valid start point.
      if ( text->Length > 0 && start >= 0 )
      {
         // Obtain the location of the search string in richTextBox1.
         int indexToText = richTextBox1->Find( text, start, RichTextBoxFinds::MatchCase );
         // Determine whether the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            returnValue = indexToText;
         }
      }

      return returnValue;
   }