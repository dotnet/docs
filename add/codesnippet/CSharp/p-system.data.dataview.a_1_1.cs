    private void CheckAllowDelete(DataRow rowToDelete)
    {
        DataView view = new DataView(DataSet1.Tables["Suppliers"]);
        if (view.AllowDelete)
            rowToDelete.Delete();
    }