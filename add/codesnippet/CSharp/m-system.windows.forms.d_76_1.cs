    public DataGridViewRow CloneWithValues(DataGridViewRow row)
    {
        DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
        for (Int32 index = 0; index < row.Cells.Count; index++)
        {
            clonedRow.Cells[index].Value = row.Cells[index].Value;
        }
        return clonedRow;
    }