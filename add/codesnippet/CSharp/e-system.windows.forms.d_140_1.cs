    private void DataGridView1_UserDeletingRow(object sender,
        DataGridViewRowCancelEventArgs e)
    {
        DataGridViewRow startingBalanceRow = DataGridView1.Rows[0];

        // Check if the Starting Balance row is included in the selected rows
        if (DataGridView1.SelectedRows.Contains(startingBalanceRow))
        {
            // Do not allow the user to delete the Starting Balance row.
            MessageBox.Show("Cannot delete Starting Balance row!");

            // Cancel the deletion if the Starting Balance row is included.
            e.Cancel = true;
        }
    }