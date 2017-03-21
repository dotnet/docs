private:
   void InitializeListViewItems()
   {
      ListView1->View = View::List;
      array<System::Windows::Forms::Cursor^>^favoriteCursors = {Cursors::Help,Cursors::Hand,Cursors::No,Cursors::Cross};
      
      // Populate the ListView control with the array of Cursors.
      System::Collections::IEnumerator^ myEnum = favoriteCursors->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         System::Windows::Forms::Cursor^ aCursor = safe_cast<System::Windows::Forms::Cursor^>(myEnum->Current);
         
         // Construct the ListViewItem object
         ListViewItem^ item = gcnew ListViewItem;
         
         // Set the Text property to the cursor name.
         item->Text = aCursor->ToString();
         
         // Set the Tag property to the cursor.
         item->Tag = aCursor;
         
         // Add the ListViewItem to the ListView.
         ListView1->Items->Add( item );
      }
   }