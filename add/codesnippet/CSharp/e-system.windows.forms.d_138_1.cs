    private void dataGridView1_CellEnter(object sender, 
        DataGridViewCellEventArgs e)
    {
        dataGridView1[e.ColumnIndex, e.RowIndex].Style
            .SelectionBackColor = Color.Blue;
    }

    private void dataGridView1_CellLeave(object sender, 
        DataGridViewCellEventArgs e)
    {
        dataGridView1[e.ColumnIndex, e.RowIndex].Style
            .SelectionBackColor = Color.Empty;
    }