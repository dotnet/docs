        // This event handler provides custom item-creation behavior.
        void OnCustomersBindingSourceAddingNew(Object^ sender, 
            AddingNewEventArgs^ e)
        {
            e->NewObject = DemoCustomer::CreateNewCustomer();
        }