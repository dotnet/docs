   // Uses the SelectedIndices property to retrieve and tally the  
   // price of the selected menu items.
   void ListView1_SelectedIndexChanged_UsingIndices( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ListView::SelectedIndexCollection^ indexes = this->ListView1->SelectedIndices;
      double price = 0.0;
      System::Collections::IEnumerator^ myEnum1 = indexes->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         int index = safe_cast<int>(myEnum1->Current);
         price += Double::Parse( this->ListView1->Items[ index ]->SubItems[ 1 ]->Text );
      }

      
      // Output the price to TextBox1.
      TextBox1->Text = price.ToString();
   }