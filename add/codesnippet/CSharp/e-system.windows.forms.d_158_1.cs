      private void myButton_Click(object sender, EventArgs e)
      {
         if(TablesAlreadyAdded) 
         {
            return;
         }
         AddCustomDataTableStyle();
      }
      private void AddCustomDataTableStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         // Map DataGridTableStyle to a DataTable.
         myTableStyle.MappingName = "Orders";
         // Get CurrencyManager object.
         CurrencyManager myCurrencyManager = (CurrencyManager)BindingContext[myDataSet,"Orders"];
         // Use the CurrencyManager to get the PropertyDescriptor for column.
         PropertyDescriptor myPropertyDescriptor = myCurrencyManager.GetItemProperties()["Amount"];
         // Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
         DataGridColumnStyle myColumnStyle =  new DataGridTextBoxColumn(myPropertyDescriptor,"c",true);
         // Add EventHandler function for PropertyDescriptorChanged Event.
         myColumnStyle.PropertyDescriptorChanged+=new System.EventHandler(MyPropertyDescriptor_Changed);
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         // Add the DataGridTableStyle instance to the GridTableStylesCollection. 
         myDataGrid.TableStyles.Add(myTableStyle);
         TablesAlreadyAdded=true;
      }
      private void MyPropertyDescriptor_Changed(object sender,EventArgs e)
      {
         myLabel.Text="Property Descriptor Property of DataGridColumnStyle has changed";
      }