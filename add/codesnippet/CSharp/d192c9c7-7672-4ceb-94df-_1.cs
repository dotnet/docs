   private void RemoveColumnStyle_Clicked(object sender, EventArgs e)
   {
      DataGridTableStyle myTableStyle = myDataGrid.TableStyles[0];

      // Get the GridColumnStylesCollection of Data Grid.
      myColumns = myTableStyle.GridColumnStyles;
      int i;

      // Remove the CustName ColumnStyle from the data grid.
      if(myColumns.Contains("CustName"))
      {
         DataGridColumnStyle myDataColumnStyle= myColumns["CustName"];
         i= myColumns.IndexOf(myDataColumnStyle);
         myColumns.RemoveAt(i);
      }
   }