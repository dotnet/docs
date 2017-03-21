      private void SetUp()
      {
         // Create a DataSet with a table.
         MakeDataSet();
         // Bind the DataGrid to the DataSet.
         myDataGrid.SetDataBinding(myDataSet, "Orders");
         myTableStyle = new DataGridTableStyle();
         // Map 'DataGridTableStyle' instance to the DataTable.
         myTableStyle.MappingName = "Orders";
         // Add EventHandler function for 'PreferredRowHeightChanged' Event.
         myTableStyle.PreferredRowHeightChanged+=new EventHandler(RowHeight_Changed);
      }
      // Called when the PreferredRowHeight property of myTableStyle is modified
      private void RowHeight_Changed(object sender, EventArgs e)
      {
         MessageBox.Show("PreferredRowHeight property is changed");
      }