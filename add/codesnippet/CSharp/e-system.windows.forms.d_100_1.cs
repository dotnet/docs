    // Forces the control to repaint itself when the user 
    // manually changes the width of a column.
    void dataGridView1_ColumnWidthChanged(object sender,
        DataGridViewColumnEventArgs e)
    {
        this.dataGridView1.Invalidate();
    }