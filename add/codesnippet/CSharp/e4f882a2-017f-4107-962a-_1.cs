    private void MakeDataView(DataSet dataSet)
    {
        DataView view = new DataView(dataSet.Tables["Suppliers"], 
            "Country = 'UK'", "CompanyName", 
            DataViewRowState.CurrentRows);
        view.AllowEdit = true;
        view.AllowNew = true;
        view.AllowDelete = true;
    }