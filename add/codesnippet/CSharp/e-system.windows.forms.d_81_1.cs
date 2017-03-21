
      private void AddCustomDataTableStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         // Map DataGridTableStyle to a DataTable.
         myTableStyle.MappingName = "Orders";
         // Get CurrencyManager object.
         CurrencyManager myCurrencyManager = (CurrencyManager)BindingContext[myDataSet,"Orders"];
         // Use the CurrencyManager to get the PropertyDescriptor for the column.
         PropertyDescriptor myPropertyDescriptor = myCurrencyManager.GetItemProperties()["Amount"];
         // Change the HeaderText.
         DataGridColumnStyle myColumnStyle = new DataGridTextBoxColumn(myPropertyDescriptor,"c",true);
         // Attach a event handler function with the 'HeaderTextChanged' event.
         myColumnStyle.HeaderTextChanged+=new EventHandler(MyHeaderText_Changed);
         myColumnStyle.Width=130;
         myColumnStyle.HeaderText="Amount in $";
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         myDataGrid.TableStyles.Add(myTableStyle);
         TablesAlreadyAdded=true;
      }

      private void MyHeaderText_Changed(object sender,EventArgs e)
      {
         myLabel.Text="Header Descriptor Property of DataGridColumnStyle has changed";
      }