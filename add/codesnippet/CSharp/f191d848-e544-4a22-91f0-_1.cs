    // Swap the last column with the first.
    private void Button10_Click(object sender, EventArgs args)
    {
        DataGridViewColumnCollection columnCollection = dataGridView.Columns;

        DataGridViewColumn firstVisibleColumn =
            columnCollection.GetFirstColumn(DataGridViewElementStates.Visible);
        DataGridViewColumn lastVisibleColumn =
            columnCollection.GetLastColumn(
                DataGridViewElementStates.Visible, DataGridViewElementStates.None);

        int firstColumn_sIndex = firstVisibleColumn.DisplayIndex;
        firstVisibleColumn.DisplayIndex = lastVisibleColumn.DisplayIndex;
        lastVisibleColumn.DisplayIndex = firstColumn_sIndex;
    }