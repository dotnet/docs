    private void CreateDataSet()
    {
        DataSet dataSet = new DataSet("SuppliersProducts");
        Console.WriteLine(dataSet.DataSetName);

        // Add a DataTable.
        dataSet.Tables.Add(new DataTable("Suppliers"));

        // Add a DataColumn to the DataTable.
        dataSet.Tables["Suppliers"].Columns.Add
            (new DataColumn("CompanyName", 
            System.Type.GetType("System.String")));
    }