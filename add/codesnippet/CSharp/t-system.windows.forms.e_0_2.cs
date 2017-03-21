private void InitializeComponent()
 {
     // Standard control setup.
     //....
     // You set the DataSource to a data set, and the DataMember to a table.
     errorProvider1.DataSource = dataSet1 ;
     errorProvider1.DataMember = dataTable1.TableName ;
     errorProvider1.ContainerControl = this ;
     errorProvider1.BlinkRate = 200 ;
     //...
     // Since the ErrorProvider control does not have a visible component,
     // it does not need to be added to the form. 
 }
 
 private void buttonSave_Click(object sender, System.EventArgs e)
 {
     // Checks for a bad post code.
     DataTable CustomersTable;
     CustomersTable = dataSet1.Tables["Customers"];
     foreach (DataRow row in (CustomersTable.Rows)) 
	 {
         if (Convert.ToBoolean(row["PostalCodeIsNull"])) 
         {
             row.RowError="The Customer details contain errors";
             row.SetColumnError("PostalCode", "Postal Code required");
         } 
     } 
 }
