    private void sortButton_Click(object sender, System.EventArgs e)
    {
        // Check which column is selected, otherwise set NewColumn to null.
        DataGridViewColumn newColumn =
            dataGridView1.Columns.GetColumnCount(
            DataGridViewElementStates.Selected) == 1 ?
            dataGridView1.SelectedColumns[0] : null;

        DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
        ListSortDirection direction;

        // If oldColumn is null, then the DataGridView is not currently sorted.
        if (oldColumn != null)
        {
            // Sort the same column again, reversing the SortOrder.
            if (oldColumn == newColumn &&
                dataGridView1.SortOrder == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }
            else
            {
                // Sort a new column and remove the old SortGlyph.
                direction = ListSortDirection.Ascending;
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }
        else
        {
            direction = ListSortDirection.Ascending;
        }

        // If no column has been selected, display an error dialog  box.
        if (newColumn == null)
        {
            MessageBox.Show("Select a single column and try again.",
                "Error: Invalid Selection", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        else
        {
            dataGridView1.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
        }
    }