   private void ResetButton_Click(object sender, EventArgs e)
   {
      DataGridTableStyle myTableStyle = myDataGrid.TableStyles[0];
      GridColumnStylesCollection myColumns= myTableStyle.GridColumnStyles;

      // Reset the property descriptor of column styles collection.
      myColumns.ResetPropertyDescriptors();
   }