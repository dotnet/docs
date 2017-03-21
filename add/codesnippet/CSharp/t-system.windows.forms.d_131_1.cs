    private void dataGridView1_RowsAdded(object sender,
         DataGridViewRowsAddedEventArgs e)
    {
        if (newRowNeeded)
        {
            newRowNeeded = false;
            numberOfRows = numberOfRows + 1;
        }
    }