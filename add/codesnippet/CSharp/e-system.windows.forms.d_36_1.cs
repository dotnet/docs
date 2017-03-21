    private void DataGridView1_CellValidated(object sender,
        DataGridViewCellEventArgs e)
    {
        // Clear any error messages that may have been set in cell validation.
        DataGridView1.Rows[e.RowIndex].ErrorText = null;
    }