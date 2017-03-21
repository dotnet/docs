    // Change the text in the column header.
    private void Button9_Click(object sender,
        EventArgs args)
    {
        foreach (DataGridViewColumn column in dataGridView.Columns)
        {

            column.HeaderText = String.Concat("Column ",
                column.Index.ToString());
        }
    }