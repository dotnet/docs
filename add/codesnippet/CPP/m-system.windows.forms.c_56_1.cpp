   void AddListItem()
   {
      
      // Get the CurrencyManager for a DataTable.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ DataTable1 ]);
      myCurrencyManager->AddNew();
   }
