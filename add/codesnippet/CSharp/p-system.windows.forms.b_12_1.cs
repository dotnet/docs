    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        // Create and populate the list of DemoCustomer objects
        // which will supply data to the DataGridView.
        List<DemoCustomer> customerList = new List<DemoCustomer>();
        customerList.Add(DemoCustomer.CreateNewCustomer());
        customerList.Add(DemoCustomer.CreateNewCustomer());
        customerList.Add(DemoCustomer.CreateNewCustomer());

        // Bind the list to the BindingSource.
        this.customersBindingSource.DataSource = customerList;

        
        // Attach the BindingSource to the DataGridView.
        this.customersDataGridView.DataSource = 
            this.customersBindingSource;
    }