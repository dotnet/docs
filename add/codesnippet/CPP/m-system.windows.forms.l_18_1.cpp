   void AddToMyListBox()
   {
      // Stop the ListBox from drawing while items are added.
      listBox1->BeginUpdate();

      // Loop through and add five thousand new items.
      for ( int x = 1; x < 5000; x++ )
      {
         listBox1->Items->Add( String::Format( "Item {0}", x ) );
      }
      listBox1->EndUpdate();
   }