private void AddListItem()
{
   // Get the CurrencyManager for a DataTable.
   CurrencyManager myCurrencyManager = 
   (CurrencyManager)this.BindingContext[DataTable1];
   myCurrencyManager.AddNew();
}
      