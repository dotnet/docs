private:
   void InitializeMyListBox()
   {
      // Add items to the ListBox.
      listBox1->Items->Add( "A" );
      listBox1->Items->Add( "C" );
      listBox1->Items->Add( "E" );
      listBox1->Items->Add( "F" );
      listBox1->Items->Add( "G" );
      listBox1->Items->Add( "D" );
      listBox1->Items->Add( "B" );

      // Sort all items added previously.
      listBox1->Sorted = true;

      // Set the SelectionMode to select multiple items.
      listBox1->SelectionMode = SelectionMode::MultiExtended;

      // Select three initial items from the list.
      listBox1->SetSelected( 0, true );
      listBox1->SetSelected( 2, true );
      listBox1->SetSelected( 4, true );

      // Force the ListBox to scroll back to the top of the list.
      listBox1->TopIndex = 0;
   }

   void InvertMySelection()
   {
      // Loop through all items the ListBox.
      for ( int x = 0; x < listBox1->Items->Count; x++ )
      {
         // Select all items that are not selected,
         // deselect all items that are selected.
         listBox1->SetSelected( x,  !listBox1->GetSelected( x ) );
      }
      listBox1->TopIndex = 0;
   }