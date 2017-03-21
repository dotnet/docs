    // Set row labels.
    private void Button6_Click(object sender, System.EventArgs e)
    {

        int rowNumber = 1;
        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow) continue;
            row.HeaderCell.Value = "Row " + rowNumber;
            rowNumber = rowNumber + 1;
        }
        dataGridView.AutoResizeRowHeadersWidth(
            DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
    }