private:
   void FindMyString( String^ searchString )
   {
      // Ensure we have a proper string to search for.
      if ( searchString != String::Empty )
      {
         // Find the item in the list and store the index to the item.
         int index = listBox1->FindString( searchString );

         // Determine if a valid index is returned. Select the item if it is valid.
         if ( index != -1 )
                  listBox1->SetSelected( index, true );
         else
                  MessageBox::Show( "The search string did not match any items in the ListBox" );
      }
   }