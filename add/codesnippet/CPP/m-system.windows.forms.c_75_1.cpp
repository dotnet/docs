   void RemoveFromList()
   {
      
      // Get the CurrencyManager of a TextBox control.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // If the count is 0, exit the function.
      if ( myCurrencyManager->Count > 1 )
            myCurrencyManager->RemoveAt( 0 );
   }
