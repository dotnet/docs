   private void Clear_Clicked(object sender, System.EventArgs e)
   {
      // TablesAlreadyAdded set to false so that table styles can be added again.
      TablesAlreadyAdded = false;
      myLabel.Text = "All Table Styles Cleared.";
      // Clear all the column styles and also table style for the grid.
      foreach (DataGridTableStyle myTableStyle in myDataGrid.TableStyles)
      {
         GridColumnStylesCollection myColumns = myTableStyle.GridColumnStyles;
         myColumns.Clear();
      }
      myDataGrid.TableStyles.Clear();
   }