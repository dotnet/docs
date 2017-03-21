private void AddCustomDataTableStyle(){
   DataGridTableStyle ts1 = new DataGridTableStyle();
   ts1.MappingName = "Customers";
   // Set other properties.
   ts1.AlternatingBackColor = Color.LightGray;

   /* Add a GridColumnStyle and set its MappingName 
   to the name of a DataColumn in the DataTable. 
   Set the HeaderText and Width properties. */
   
   DataGridColumnStyle boolCol = new DataGridBoolColumn();
   boolCol.MappingName = "Current";
   boolCol.HeaderText = "IsCurrent Customer";
   boolCol.Width = 150;
   ts1.GridColumnStyles.Add(boolCol);
   
   // Add a second column style.
   DataGridColumnStyle TextCol = new DataGridTextBoxColumn();
   TextCol.MappingName = "custName";
   TextCol.HeaderText = "Customer Name";
   TextCol.Width = 250;
   ts1.GridColumnStyles.Add(TextCol);

   // Create the second table style with columns.
   DataGridTableStyle ts2 = new DataGridTableStyle();
   ts2.MappingName = "Orders";

   // Set other properties.
   ts2.AlternatingBackColor = Color.LightBlue;
   
   // Create new ColumnStyle objects.
   DataGridColumnStyle cOrderDate = 
   new DataGridTextBoxColumn();
   cOrderDate.MappingName = "OrderDate";
   cOrderDate.HeaderText = "Order Date";
   cOrderDate.Width = 100;
   ts2.GridColumnStyles.Add(cOrderDate);

   /*Use a PropertyDescriptor to create a formatted
   column. First get the PropertyDescriptorCollection
   for the data source and data member. */
   System.ComponentModel.PropertyDescriptorCollection pcol = 
      this.BindingContext[myDataSet, "Customers.custToOrders"]
      .GetItemProperties();
 
   /* Create a formatted column using a PropertyDescriptor.
   The formatting character "c" specifies a currency format. */     
   DataGridColumnStyle csOrderAmount = 
   new DataGridTextBoxColumn(pcol["OrderAmount"], "c", true);
   csOrderAmount.MappingName = "OrderAmount";
   csOrderAmount.HeaderText = "Total";
   csOrderAmount.Width = 100;
   ts2.GridColumnStyles.Add(csOrderAmount);

   /* Add the DataGridTableStyle instances to 
   the GridTableStylesCollection. */
   myDataGrid.TableStyles.Add(ts1);
   myDataGrid.TableStyles.Add(ts2);
}