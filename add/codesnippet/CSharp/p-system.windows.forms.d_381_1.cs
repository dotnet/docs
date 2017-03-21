    // Set a thick horizontal edge.
    private void Button7_Click(object sender,
        System.EventArgs e)
    {
        int secondRow = 1;
        DataGridViewRow row = dataGridView.Rows[secondRow];
        row.DividerHeight = 10;
    }