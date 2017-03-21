    private void ToolTips()
    {
        DataGridViewColumn firstColumn = dataGridView.Columns[0];
        DataGridViewColumn thirdColumn = dataGridView.Columns[2];
        firstColumn.ToolTipText =
            "This column uses a default cell.";
        thirdColumn.ToolTipText =
            "This column uses a template cell." +
            " Style changes to one cell apply to all cells.";
    }