    // Display NullValue for cell values equal to DataSourceNullValue.
    private void dataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        String value = e.Value as string;
        if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))
        {
            e.Value = e.CellStyle.NullValue;
            e.FormattingApplied = true;
        }
    }