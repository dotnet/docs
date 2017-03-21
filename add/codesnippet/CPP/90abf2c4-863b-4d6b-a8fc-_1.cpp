   void AddArray()
   {
      /* Get three CurrencyManager objects used to construct
        DataGridTableSTyle objects. */
      CurrencyManager^ customersManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      CurrencyManager^ regionsManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      CurrencyManager^ productsManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      DataGridTableStyle^ gridCustomers = gcnew DataGridTableStyle( customersManager );
      DataGridTableStyle^ gridRegions = gcnew DataGridTableStyle( regionsManager );
      DataGridTableStyle^ gridProducts = gcnew DataGridTableStyle( productsManager );
      
      // Create a DataGridTableStyle array.
      array<DataGridTableStyle^>^myGrids = {gridCustomers,gridRegions,gridProducts};
      
      // Use AddRange to add to the collection.
      myDataGrid->TableStyles->AddRange( myGrids );
   }