    // Set the vertical edge.
    private void Button7_Click(object sender,
        System.EventArgs e)
    {
        int thirdColumn = 2;
        DataGridViewColumn column =
            dataGridView.Columns[thirdColumn];
        column.DividerWidth = 10;
    }