      private void AlignmentChanged_Click(object sender, EventArgs e)
      {
           myMessage = "Alignment has been Changed"; 
      }
      private void AddCustomDataTableStyle()
      {
         // Create a 'DataGridTableStyle'.
         DataGridTableStyle myDataTableStyle = new DataGridTableStyle();
         myDataTableStyle.MappingName = "Customers";
         // Create a 'DataGridColumnStyle'.
         myDataGridColumnStyle = new DataGridTextBoxColumn();
         myDataGridColumnStyle.MappingName = "CustName";
         myDataGridColumnStyle.HeaderText = "Customer Name";
         myDataGridColumnStyle.Width = 250;
         myDataGridColumnStyle.AlignmentChanged+=new EventHandler(AlignmentChanged_Click);
         // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
         myDataTableStyle.GridColumnStyles.Add(myDataGridColumnStyle);
         // Add the 'DataGridTableStyle' to 'DataGrid'.
         myDataGrid.TableStyles.Add(myDataTableStyle);
      }