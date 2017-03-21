        private void button1_Click(object sender, EventArgs e)
        {
            // Create the connection string, data adapter and data table.
            SqlConnection connectionString =
                 new SqlConnection("Initial Catalog=Northwind;" +
                 "Data Source=localhost;Integrated Security=SSPI;");
            SqlDataAdapter customersTableAdapter =
                new SqlDataAdapter("Select * from Customers", connectionString);
            DataTable customerTable = new DataTable();

            // Fill the the adapter with the contents of the customer table.
            customersTableAdapter.Fill(customerTable);

            // Set data source for BindingSource1.
            BindingSource1.DataSource = customerTable;

            // Set the label text to the number of items in the collection before
            // an item is removed.
            label1.Text = "Starting count: " + BindingSource1.Count.ToString();

            // Access the List property and remove an item.
            BindingSource1.List.RemoveAt(4);

            // Remove an item directly from the BindingSource. 
            // This is equivalent to the previous line of code.
            BindingSource1.RemoveAt(4);

            // Show the new count.
            label2.Text = "Count after removal: " + BindingSource1.Count.ToString();
        }