   private void AddArray()
   {
   

   /* Get three CurrencyManager objects used to construct 
   DataGridTableSTyle objects. */
   CurrencyManager customersManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];

   CurrencyManager regionsManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];

   CurrencyManager productsManager = (CurrencyManager)
   this.BindingContext[myDataSet, "Customers"];


   DataGridTableStyle gridCustomers = 
   new DataGridTableStyle(customersManager);
   DataGridTableStyle gridRegions = 
   new DataGridTableStyle(regionsManager);
   DataGridTableStyle gridProducts = 
   new DataGridTableStyle(productsManager);

   // Create a DataGridTableStyle array.
   DataGridTableStyle[] myGrids = {gridCustomers, gridRegions, gridProducts};

   // Use AddRange to add to the collection.
   myDataGrid.TableStyles.AddRange(myGrids);

   }