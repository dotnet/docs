   void PrintListItems()
   {
      
      // Get the CurrencyManager of a TextBox control.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(textBox1->BindingContext[nullptr]);
      
      // Presuming the list is a DataView, create a DataRowView variable.
      DataRowView^ drv;
      for ( int i = 0; i < myCurrencyManager->Count; i++ )
      {
         myCurrencyManager->Position = i;
         drv = dynamic_cast<DataRowView^>(myCurrencyManager->Current);
         
         // Presuming a column named CompanyName exists.
         Console::WriteLine( drv[ "CompanyName" ] );

      }
   }
