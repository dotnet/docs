    private void dataGridView1_CellBeginEdit(object sender,
        DataGridViewCellCancelEventArgs e)
    {
        string msg = String.Format("Editing Cell at ({0}, {1})",
            e.ColumnIndex, e.RowIndex);
        this.Text = msg;
    }

    private void dataGridView1_CellEndEdit(object sender,
        DataGridViewCellEventArgs e)
    {
        string msg = String.Format("Finished Editing Cell at ({0}, {1})",
            e.ColumnIndex, e.RowIndex);
        this.Text = msg;
    }