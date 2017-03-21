    private void CustomizeCellsInThirdColumn()
    {
        int thirdColumn = 2;
        DataGridViewColumn column =
            dataGridView.Columns[thirdColumn];
        DataGridViewCell cell = new DataGridViewTextBoxCell();

        cell.Style.BackColor = Color.Wheat;
        column.CellTemplate = cell;
    }