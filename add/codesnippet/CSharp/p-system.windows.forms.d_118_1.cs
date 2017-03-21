    private void dataGridView1_CellValueNeeded(object sender,
        System.Windows.Forms.DataGridViewCellValueEventArgs e)
    {
        // If this is the row for new records, no values are needed.
        if (e.RowIndex == this.dataGridView1.RowCount - 1) return;

        Customer customerTmp = null;

        // Store a reference to the Customer object for the row being painted.
        if (e.RowIndex == rowInEdit)
        {
            customerTmp = this.customerInEdit;
        }
        else 
        {
            customerTmp = (Customer)this.customers[e.RowIndex];
        }

        // Set the cell value to paint using the Customer object retrieved.
        switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
        {
            case "Company Name":
                e.Value = customerTmp.CompanyName;
                break;

            case "Contact Name":
                e.Value = customerTmp.ContactName;
                break;
        }
    }