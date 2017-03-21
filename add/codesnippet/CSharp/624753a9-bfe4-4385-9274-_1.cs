    // Workaround for bug that prevents DataGridViewRowCollection.InsertRange
    // from working when any rows before the insertion index are selected.
    private void InsertRows(int index, params DataGridViewRow[] rows)
    {
        System.Collections.Generic.List<int> selectedIndexes =
            new System.Collections.Generic.List<int>();
        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        {
            if (row.Index >= index)
            {
                selectedIndexes.Add(row.Index);
                row.Selected = false;
            }
        }
        dataGridView1.Rows.InsertRange(index, rows);
        foreach (int selectedIndex in selectedIndexes)
        {
            dataGridView1.Rows[selectedIndex].Selected = true;
        }
    }