      private void AddCustomDataTableStyle()
      {
         myDataGridTableStyle1 = new DataGridTableStyle();
         myDataGridTableStyle2 = new DataGridTableStyle();

         MessageBox.Show("LinkColor Before : "
            +myDataGridTableStyle1.LinkColor);
         MessageBox.Show("HeaderFont Before : "
            +myDataGridTableStyle1.HeaderFont);
         
         myDataGridTableStyle1.LinkColorChanged +=
            new System.EventHandler(LinkColorChanged_Handler);
         myDataGridTableStyle1.HeaderFontChanged 
            += new System.EventHandler(HeaderFontChanged_Handler);
         myDataGridTableStyle1.MappingName = "Customers";

         // Set other properties.
         myDataGridTableStyle1.AlternatingBackColor = Color.LightGray;
         myDataGridTableStyle1.LinkColor = Color.Red;         
         myDataGridTableStyle1.HeaderFont = 
            new System.Drawing.Font("Verdana",
               8.25F,
               System.Drawing.FontStyle.Bold, 
               System.Drawing.GraphicsUnit.Point,
               ((System.Byte)(0)));

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

         // Create new ColumnStyle objects
         DataGridColumnStyle cOrderDate = new DataGridTextBoxColumn();
         cOrderDate.MappingName = "OrderDate";
         cOrderDate.HeaderText = "Order Date";
         cOrderDate.Width = 100;

         // PropertyDescriptor to create a formatted column.
         PropertyDescriptorCollection myPropertyDescriptorCollection = this.BindingContext
            [myDataSet, "Customers.custToOrders"].GetItemProperties(); 
         
         DataGridColumnStyle csOrderAmount = 
            new DataGridTextBoxColumn(myPropertyDescriptorCollection["OrderAmount"], "c", true);
         csOrderAmount.MappingName = "OrderAmount";
         csOrderAmount.HeaderText = "Total";
         csOrderAmount.Width = 100;
              
         // Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1);
      
      }
      private void LinkColorChanged_Handler(object sender,EventArgs e)
      {         
        MessageBox.Show("LinkColor changed to 'RED'", "DataGridTableStyle");
      }

      private void HeaderFontChanged_Handler(object sender,EventArgs e)
      {                  
         MessageBox.Show("HeaderFont changed to 'VERDANA'",
            "DataGridTableStyle");
      }