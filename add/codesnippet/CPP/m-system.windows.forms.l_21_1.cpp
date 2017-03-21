private:
   void FindMySpecificString( String^ searchString )
   {
      // Ensure we have a proper string to search for.
      if ( searchString != String::Empty )
      {
         // Find the item in the list and store the index to the item.
         int index = listBox1->FindStringExact( searchString );

         // Determine if a valid index is returned. Select the item if it is valid.
         if ( index != ListBox::NoMatches )
                  listBox1->SetSelected( index, true );
         else
                  MessageBox::Show( "The search string did not find any items in the ListBox that exactly match the specified search string" );
      }
   }