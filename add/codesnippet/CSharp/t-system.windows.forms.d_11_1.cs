    private void dataGridView1_DataError(object sender,
        DataGridViewDataErrorEventArgs e)
    {
        // If the data source raises an exception when a cell value is 
        // commited, display an error message.
        if (e.Exception != null &&
            e.Context == DataGridViewDataErrorContexts.Commit)
        {
            MessageBox.Show("CustomerID value must be unique.");
        }
    }