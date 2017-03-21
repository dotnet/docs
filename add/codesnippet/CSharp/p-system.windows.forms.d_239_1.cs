      private void Create_Table()
      {
         // Create a DataSet.
         myDataSet = new DataSet("myDataSet");
         // Create DataTable.
         DataTable myCustomerTable = new DataTable("Customers");
         // Create two columns, and add to the table.
         DataColumn CustID = new DataColumn("CustID", typeof(int));
         DataColumn CustName = new DataColumn("CustName");
         myCustomerTable.Columns.Add(CustID);
         myCustomerTable.Columns.Add(CustName);
         DataRow newRow1;
         // Create three customers in the Customers Table.
         for(int i = 1; i < 3; i++)
         {
            newRow1 = myCustomerTable.NewRow();
            newRow1["custID"] = i;
            // Add row to the Customers table.
            myCustomerTable.Rows.Add(newRow1);
         }
         // Give each customer a distinct name.
         myCustomerTable.Rows[0]["custName"] = "Alpha";
         myCustomerTable.Rows[1]["custName"] = "Beta";
         // Add table to DataSet.
         myDataSet.Tables.Add(myCustomerTable);
         dataGrid1.SetDataBinding(myDataSet,"Customers");
         myTableStyle = new DataGridTableStyle();
         myTableStyle.MappingName = "Customers";
         myTableStyle.ForeColor  = Color.DarkMagenta;
         dataGrid1.TableStyles.Add(myTableStyle);
      }

      // Set table's forecolor.
      private void OnForeColor_Click(object sender, System.EventArgs e)
      {
         dataGrid1.TableStyles.Clear();
         switch(myComboBox.SelectedItem.ToString())
         {
            case "Green":
               myTableStyle.ForeColor = Color.Green;
               break;
            case "Red":
               myTableStyle.ForeColor = Color.Red;
               break;
            case "Violet":
               myTableStyle.ForeColor = Color.Violet;
               break;
         }
         dataGrid1.TableStyles.Add(myTableStyle);
      }