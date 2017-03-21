    private void dataGridView1_UserDeletingRow(object sender,
        System.Windows.Forms.DataGridViewRowCancelEventArgs e)
    {
        if (e.Row.Index < this.customers.Count)
        {
            // If the user has deleted an existing row, remove the 
            // corresponding Customer object from the data store.
            this.customers.RemoveAt(e.Row.Index);
        }

        if (e.Row.Index == this.rowInEdit)
        {
            // If the user has deleted a newly created row, release
            // the corresponding Customer object. 
            this.rowInEdit = -1;
            this.customerInEdit = null;
        }
    }