    private void getCurrentCellButton_Click(object sender, System.EventArgs e)
    {
        string msg = String.Format("Row: {0}, Column: {1}",
            dataGridView1.CurrentCell.RowIndex,
            dataGridView1.CurrentCell.ColumnIndex);
        MessageBox.Show(msg, "Current Cell");
    }