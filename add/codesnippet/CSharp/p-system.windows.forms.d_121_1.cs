    // Give cheescake excellent rating.
    private void Button8_Click(object sender,
        System.EventArgs e)
    {
        UpdateStars(dataGridView.Rows[4], "******************");
    }

    int ratingColumn = 3;

    private void UpdateStars(DataGridViewRow row, string stars)
    {

        row.Cells[ratingColumn].Value = stars;

        // Resize the column width to account for the new value.
        row.DataGridView.AutoResizeColumn(ratingColumn, 
            DataGridViewAutoSizeColumnMode.DisplayedCells);
    }