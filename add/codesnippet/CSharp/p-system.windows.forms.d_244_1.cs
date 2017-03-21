
      private void DataGridTableStyle_Sample_Load(object sender,
                                                EventArgs e)
      {
         myDataGridTableStyle1 = new DataGridTableStyle();
         myHeaderLabel.Text = "Header Status :" 
            + myDataGridTableStyle1.ColumnHeadersVisible.ToString();
         if(myDataGridTableStyle1.ColumnHeadersVisible == true)
         {
            btnheader.Text = "Remove Header";
         }
         else
         {
            btnheader.Text = "Add Header";
         }
         AddCustomDataTableStyle();
      } 
      private void AddCustomDataTableStyle()
      {           
         myDataGridTableStyle1.ColumnHeadersVisibleChanged 
            += new System.EventHandler(ColumnHeadersVisibleChanged_Handler);

         // Set ColumnheaderVisible property.         
         myDataGridTableStyle1.MappingName = "Customers";

         // Add a GridColumnStyle and set its MappingName 
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
 
         // Create a formatted column using a PropertyDescriptor.         
         DataGridColumnStyle csOrderAmount = 
            new DataGridTextBoxColumn(myPropertyDescriptorCollection["OrderAmount"], "c", true);
         csOrderAmount.MappingName = "OrderAmount";
         csOrderAmount.HeaderText = "Total";
         csOrderAmount.Width = 100;

         // Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid.TableStyles.Add(myDataGridTableStyle1);              
      }          
      private void ColumnHeadersVisibleChanged_Handler(object sender,
                                                            EventArgs e)
      {         
         myHeaderLabel.Text = "Header Status :" 
            + myDataGridTableStyle1.ColumnHeadersVisible.ToString();
      }      
      private void btnheader_Click(object sender, EventArgs e)
      {
         if(myDataGridTableStyle1.ColumnHeadersVisible == true)
         {            
            myDataGridTableStyle1.ColumnHeadersVisible = false;
            btnheader.Text = "Add Header";
         }
         else
         {
            myDataGridTableStyle1.ColumnHeadersVisible = true;
            btnheader.Text = "Remove Header";
         }         
     }     