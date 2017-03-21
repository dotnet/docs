    private void dataGridView1_SortCompare(object sender,
        DataGridViewSortCompareEventArgs e)
    {
        // Try to sort based on the cells in the current column.
        e.SortResult = System.String.Compare(
            e.CellValue1.ToString(), e.CellValue2.ToString());

        // If the cells are equal, sort based on the ID column.
        if (e.SortResult == 0 && e.Column.Name != "ID")
        {
            e.SortResult = System.String.Compare(
                dataGridView1.Rows[e.RowIndex1].Cells["ID"].Value.ToString(),
                dataGridView1.Rows[e.RowIndex2].Cells["ID"].Value.ToString());
        }
        e.Handled = true;
    }