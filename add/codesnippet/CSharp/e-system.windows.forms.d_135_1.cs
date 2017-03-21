    private void dataGridView1_CellMouseEnter(object sender,
        DataGridViewCellEventArgs e)
    {
        Bitmap markingUnderMouse = (Bitmap)dataGridView1.
               Rows[e.RowIndex].
               Cells[e.ColumnIndex].Value;

        if (markingUnderMouse == blank)
        {
            dataGridView1.Cursor = Cursors.Default;
        }
        else if (markingUnderMouse == o || markingUnderMouse == x)
        {
            dataGridView1.Cursor = Cursors.No;
            ToolTip(e, true);
        }
    }

    private void ToolTip(DataGridViewCellEventArgs e, bool showTip)
    {
        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1
            .Rows[e.RowIndex].Cells[e.ColumnIndex];
        DataGridViewImageColumn imageColumn =
            (DataGridViewImageColumn)
            dataGridView1.Columns[cell.ColumnIndex];

        if (showTip) cell.ToolTipText = imageColumn.Description;
        else { cell.ToolTipText = String.Empty; }
    }

    private void dataGridView1_CellMouseLeave(object sender,
        DataGridViewCellEventArgs e)
    {
        ToolTip(e, false);
        dataGridView1.Cursor = Cursors.Default;
    }