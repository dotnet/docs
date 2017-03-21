   // Handles the ItemChecked event.  The method loops through all the 
   // checked items and tallies a new price each time an item is 
   // checked or unchecked. It outputs the price to TextBox1.
   void ListView1_ItemCheck2( Object^ /*sender*/, System::Windows::Forms::ItemCheckEventArgs^ e )
   {
      double price = 0.0;
      ListView::CheckedListViewItemCollection^ checkedItems = ListView1->CheckedItems;
      System::Collections::IEnumerator^ myEnum = checkedItems->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum->Current);
         price += Double::Parse( item->SubItems[ 1 ]->Text );
      }

      if ( e->CurrentValue == CheckState::Unchecked )
      {
         price += Double::Parse( this->ListView1->Items[ e->Index ]->SubItems[ 1 ]->Text );
      }
      else
      if ( (e->CurrentValue == CheckState::Checked) )
      {
         price -= Double::Parse( this->ListView1->Items[ e->Index ]->SubItems[ 1 ]->Text );
      }

      // Output the price to TextBox1.
      TextBox1->Text = price.ToString();
   }