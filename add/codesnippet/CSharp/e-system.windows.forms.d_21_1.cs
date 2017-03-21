      private void AddCustomDataTableStyle()
      {
         myDataGridTableStyle1 = new DataGridTableStyle();
         myDataGridTableStyle1.MappingNameChanged+=
            new System.EventHandler(MappingNameChanged_Handler);
         myDataGridTableStyle1.GridLineStyleChanged += 
            new System.EventHandler(GridLineStyleChanged_Handler);
         myDataGridTableStyle1.MappingName = "Customers";

         // Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = Color.LightGray;
         myDataGridTableStyle1.GridLineStyle=
            System.Windows.Forms.DataGridLineStyle.None;

         // Add a GridColumnStyle and set its MappingName.          
         DataGridColumnStyle myBoolCol = new DataGridBoolColumn();
         myBoolCol.MappingName = "Current";
         myBoolCol.HeaderText = "IsCurrent Customer";
         myBoolCol.Width = 150;
         myDataGridTableStyle1.GridColumnStyles.Add(myBoolCol);
      
         // Add a second column style.
         DataGridColumnStyle myTextCol = new DataGridTextBoxColumn();
         myTextCol.MappingName = "custName";
         myTextCol.HeaderText = "Customer Name";
         myTextCol.Width = 250;
         myDataGridTableStyle1.GridColumnStyles.Add(myTextCol);

         // Create new ColumnStyle objects.
         DataGridColumnStyle cOrderDate = new DataGridTextBoxColumn();
         cOrderDate.MappingName = "OrderDate";
         cOrderDate.HeaderText = "Order Date";
         cOrderDate.Width = 100;

         // Use PropertyDescriptor to create a formatted column.         
         PropertyDescriptorCollection myPropertyDescriptorCollection = this.BindingContext
            [myDataSet, "Customers.custToOrders"].GetItemProperties();         
         DataGridColumnStyle csOrderAmount = 
            new DataGridTextBoxColumn(myPropertyDescriptorCollection["OrderAmount"], "c", true);
         csOrderAmount.MappingName = "OrderAmount";
         csOrderAmount.HeaderText = "Total";
         csOrderAmount.Width = 100;
              
         // Add the DataGridTableStyle object to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1);      
      }
      private void MappingNameChanged_Handler(object sender,EventArgs e)
      {         
         MessageBox.Show("MappingName Changed", "DataGridTableStyle");
      }
      private void GridLineStyleChanged_Handler(object sender,EventArgs e)
      {
         MessageBox.Show("GridLineStyle  Changed", "DataGridTableStyle");
      }    