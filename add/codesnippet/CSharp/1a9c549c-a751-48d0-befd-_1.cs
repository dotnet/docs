   // Create a DataSet with a table and populate it.
   private void MakeDataSet()
   {
      myDataSet = new DataSet("myDataSet");

      DataTable tPer = new DataTable("Person");

      DataColumn cPerName = new DataColumn("PersonName");
      tPer.Columns.Add(cPerName);

      myDataSet.Tables.Add(tPer);

      DataRow newRow1;

      for(int i = 1; i < 6; i++)
      {
         newRow1 = tPer.NewRow();
         tPer.Rows.Add(newRow1);
      }
   
      tPer.Rows[0]["PersonName"] = "Robert";
      tPer.Rows[1]["PersonName"] = "Michael";
      tPer.Rows[2]["PersonName"] = "John";
      tPer.Rows[3]["PersonName"] = "Walter";
      tPer.Rows[4]["PersonName"] = "Simon";

      // Bind the 'DataSet' to the 'DataGrid'.
      myDataGrid.SetDataBinding(myDataSet, "Person");
      myDataGridTextBox.DataBindings.Add("Text",myDataSet,"Person.PersonName");
      // Set the DataGrid to the DataGridTextBox.
      myDataGridTextBox.SetDataGrid(myDataGrid);
   }