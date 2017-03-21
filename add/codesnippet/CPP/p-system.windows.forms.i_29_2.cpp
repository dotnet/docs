   double price;

   // Handles the ItemCheck event. The method uses the CurrentValue
   // property of the ItemCheckEventArgs to retrieve and tally the  
   // price of the menu items selected.  
   void ListView1_ItemCheck1( Object^ /*sender*/, System::Windows::Forms::ItemCheckEventArgs^ e )
   {
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