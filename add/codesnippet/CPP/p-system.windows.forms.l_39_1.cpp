private:
   void SizeMyListBox()
   {
      // Add items to the ListBox.
      for ( int x = 0; x < 20; x++ )
      {
         listBox1->Items->Add( String::Format( "Item {0}", x ) );
      }
      listBox1->Height = listBox1->PreferredHeight;
   }