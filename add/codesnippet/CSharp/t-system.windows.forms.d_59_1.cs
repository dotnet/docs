    // Sets the ToolTip text for cells in the Rating column.
    void dataGridView1_CellFormatting(object sender, 
        DataGridViewCellFormattingEventArgs e)
    {
        if ( (e.ColumnIndex == this.dataGridView1.Columns["Rating"].Index)
            && e.Value != null )
        {
            DataGridViewCell cell = 
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (e.Value.Equals("*"))
            {                
                cell.ToolTipText = "very bad";
            }
            else if (e.Value.Equals("**"))
            {
                cell.ToolTipText = "bad";
            }
            else if (e.Value.Equals("***"))
            {
                cell.ToolTipText = "good";
            }
            else if (e.Value.Equals("****"))
            {
                cell.ToolTipText = "very good";
            }
        }
    }