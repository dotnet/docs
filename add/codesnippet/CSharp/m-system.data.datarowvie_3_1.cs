    private void DeleteRow()
    {
        DataRowView row;
        DataView view = (DataView) dataGrid1.DataSource;
        row = view[dataGrid1.CurrentCell.RowNumber];
        row.Delete();
    }