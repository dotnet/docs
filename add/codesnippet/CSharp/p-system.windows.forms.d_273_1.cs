    void dataGridView1_ColumnHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.ColumnHeaderSelect;
        this.dataGridView1.Columns[e.ColumnIndex].HeaderCell
            .SortGlyphDirection = SortOrder.None;
        this.dataGridView1.Columns[e.ColumnIndex].Selected = true;
    }

    void dataGridView1_RowHeaderMouseClick(
        object sender, DataGridViewCellMouseEventArgs e)
    {
        this.dataGridView1.SelectionMode =
            DataGridViewSelectionMode.RowHeaderSelect;
        this.dataGridView1.Rows[e.RowIndex].Selected = true;
    }