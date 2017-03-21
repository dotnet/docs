    private void AddNewDataRowView(DataView view)
    {
        DataRowView rowView = view.AddNew();

        // Change values in the DataRow.
        rowView["ColumnName"] = "New value";
        rowView.EndEdit();
    }