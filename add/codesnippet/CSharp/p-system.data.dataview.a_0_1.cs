    private void AddNew()
    {
        DataTable table = new DataTable();

        // Not shown: code to populate DataTable.

        DataView view = new DataView(table);
        view.AllowNew = true;
        DataRowView rowView = view.AddNew();
        rowView["ProductName"] = "New Product Name";
    }