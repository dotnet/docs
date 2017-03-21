    private void SetDataRowView()
    {
        DataView view = (DataView) dataGrid1.DataSource;

        // Set the filter to display only those rows that were modified.
        view.RowStateFilter=DataViewRowState.ModifiedCurrent;

        // Change the value of the CompanyName column for each modified row.
        foreach(DataRowView rowView in view)
        {
            rowView["CompanyName"] += " new value";
        }
    }