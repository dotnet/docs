    // This event handler provides custom item-creation behavior.
    void customersBindingSource_AddingNew(
        object sender, 
        AddingNewEventArgs e)
    {
        e.NewObject = DemoCustomer.CreateNewCustomer();
    }