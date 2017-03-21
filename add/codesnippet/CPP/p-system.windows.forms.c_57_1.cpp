   void GetCurrentItem()
   {
      CurrencyManager^ myCurrencyManager;
      
      // Get the CurrencyManager of a TextBox control.
      myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // Get the current item cast as a DataRowView.
      DataRowView^ myDataRowView;
      myDataRowView = dynamic_cast<DataRowView^>(myCurrencyManager->Current);
      
      // Print the column named ContactName.
      Console::WriteLine( myDataRowView[ "ContactName" ] );
   }
