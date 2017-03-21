    private void dataGridView1_CellStateChanged(object sender,
        DataGridViewCellStateChangedEventArgs e)
    {
        DataGridViewElementStates state = e.StateChanged;
        string msg = String.Format("Row {0}, Column {1}, {2}",
            e.Cell.RowIndex, e.Cell.ColumnIndex, e.StateChanged);
        MessageBox.Show(msg, "Cell State Changed");
    }