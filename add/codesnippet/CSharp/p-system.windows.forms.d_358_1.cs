    // Style and number columns.
    private void Button8_Click(object sender,
        EventArgs args)
    {
        DataGridViewCellStyle style = new DataGridViewCellStyle();
        style.Alignment =
            DataGridViewContentAlignment.MiddleCenter;
        style.ForeColor = Color.IndianRed;
        style.BackColor = Color.Ivory;

        foreach (DataGridViewColumn column in dataGridView.Columns)
        {
            column.HeaderCell.Value = column.Index.ToString();
            column.HeaderCell.Style = style;
        }
    }