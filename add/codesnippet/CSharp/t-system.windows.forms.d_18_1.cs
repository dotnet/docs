    private DataGridViewCell clickedCell;

    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
	// If the user right-clicks a cell, store it for use by the shortcut menu.
        if (e.Button == MouseButtons.Right)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                clickedCell =
                    dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];
            }
        }
    }