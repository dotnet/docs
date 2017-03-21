    private void MakeDataView()
    {
        DataView view = new DataView(DataSet1.Tables["Suppliers"]);

        // Bind a ComboBox control to the DataView.
        Combo1.DataSource = view;
        Combo1.DisplayMember = "Suppliers.CompanyName";
    }