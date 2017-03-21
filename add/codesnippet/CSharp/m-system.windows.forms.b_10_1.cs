    // This event handler changes the value of the CompanyName
    // property for the first item in the list.
    void changeItemBtn_Click(object sender, EventArgs e)
    {
        // Get a reference to the list from the BindingSource.
        List<DemoCustomer> customerList = 
            this.customersBindingSource.DataSource as List<DemoCustomer>;

        // Change the value of the CompanyName property for the 
        // first item in the list.
        customerList[0].CompanyName = "Tailspin Toys";

        // Call ResetItem to alert the BindingSource that the 
        // list has changed.
        this.customersBindingSource.ResetItem(0);
    }