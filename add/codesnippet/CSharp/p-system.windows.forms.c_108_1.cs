private void Grid_Navigate(object sender, NavigateEventArgs e){
   if (e.Forward ){
      DataSet ds = (DataSet) grid.DataSource;
      CurrencyManager cm  = 
      (CurrencyManager)BindingContext[ds,"Customers.CustOrders"];
      // Cast the IList to a DataView to set the AllowNew property.
      DataView dv  = (DataView) cm.List;
      dv.AllowNew = false;
   }
}