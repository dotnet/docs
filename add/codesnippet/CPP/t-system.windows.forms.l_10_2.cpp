   // Uses the SelectedItems property to retrieve and tally the price 
   // of the selected menu items.
   void ListView1_SelectedIndexChanged_UsingItems( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ListView::SelectedListViewItemCollection^ breakfast = this->ListView1->SelectedItems;
      double price = 0.0;
      System::Collections::IEnumerator^ myEnum = breakfast->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum->Current);
         price += Double::Parse( item->SubItems[ 1 ]->Text );
      }

      // Output the price to TextBox1.
      TextBox1->Text = price.ToString();
   }