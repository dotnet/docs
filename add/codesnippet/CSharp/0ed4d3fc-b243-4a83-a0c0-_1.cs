
   private void MyAddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet'.
      CurrencyManager myCurrencyManger =
               (CurrencyManager)this.BindingContext[myDataSet];

      DataGridTableStyle myTableStyle = new DataGridTableStyle();
      myTableStyle.MappingName = "Customers";

      PropertyDescriptor proprtyDescriptorName =
               myCurrencyManger.GetItemProperties()["CustName"];

      DataGridColumnStyle myCustomerNameStyle =
               new DataGridTextBoxColumn(proprtyDescriptorName);

      myCustomerNameStyle.MappingName = "custName";
      myCustomerNameStyle.HeaderText = "Customer Name";
      myTableStyle.GridColumnStyles.Add(myCustomerNameStyle);

      // Add style for 'Date' column.
      PropertyDescriptor myDateDescriptor =
               myCurrencyManger.GetItemProperties()["Date"];
      // 'G' is for MM/dd/yyyy HH:mm:ss date format.
      DataGridColumnStyle myDateStyle =
               new DataGridTextBoxColumn(myDateDescriptor,"G");

      myDateStyle.MappingName = "Date";
      myDateStyle.HeaderText = "Date";
      myDateStyle.Width = 150;
      myTableStyle.GridColumnStyles.Add(myDateStyle);

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid.TableStyles.Add(myTableStyle);
   }
