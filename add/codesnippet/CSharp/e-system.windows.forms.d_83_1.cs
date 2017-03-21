      private void AddCustomColumnStyle()
      {
         DataGridTableStyle myTableStyle = new DataGridTableStyle();
         myTableStyle.MappingName = "Orders";
         myColumnStyle =  new DataGridTextBoxColumn();
         myColumnStyle.MappingName="Orders";
         myColumnStyle.HeaderText="Orders";
         myTableStyle.GridColumnStyles.Add(myColumnStyle);
         myDataGrid.TableStyles.Add(myTableStyle);
         myColumnStyle.MappingNameChanged+=new EventHandler(columnStyle_MappingNameChanged);
         flag=true;
      }
      // MappingNameChanged event handler of DataGridColumnStyle.
      private void columnStyle_MappingNameChanged(object sender, EventArgs e)
      {
         MessageBox.Show("Mapping Name changed");
      }