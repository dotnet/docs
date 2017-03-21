    // AutoSize the third column.
    private void Button6_Click(object sender,
        System.EventArgs e)
    {
        DataGridViewColumn column = dataGridView.Columns[2];
        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
    }