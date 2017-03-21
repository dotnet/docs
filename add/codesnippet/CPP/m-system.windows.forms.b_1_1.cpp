    private:
       
        void OnMainFormLoad(Object^ sender, EventArgs^ e)
        {
            // Add a DemoCustomer to cause a row to be displayed.
            this->customersBindingSource->AddNew();
              
            // Bind the BindingSource to the DataGridView 
            // control's DataSource.
            this->customersDataGridView->DataSource = 
                this->customersBindingSource;
        }