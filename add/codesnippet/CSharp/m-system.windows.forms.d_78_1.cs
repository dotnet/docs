    // Forces the row to repaint itself when the user changes the 
    // current cell. This is necessary to refresh the focus rectangle.
    void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
    {
        if (oldRowIndex != -1)
        {
            this.dataGridView1.InvalidateRow(oldRowIndex);
        }
        oldRowIndex = this.dataGridView1.CurrentCellAddress.Y;
    }