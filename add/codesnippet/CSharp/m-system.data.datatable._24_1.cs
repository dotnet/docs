    private void ComputeBySalesSalesID(DataSet dataSet)
    {
        // Presumes a DataTable named "Orders" that has a column named "Total."
        DataTable table;
        table = dataSet.Tables["Orders"];

        // Declare an object variable.
        object sumObject;
        sumObject = table.Compute("Sum(Total)", "EmpID = 5");
    }