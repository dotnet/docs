    public void CreateOdbcParameter()
    {
        OdbcParameter parameter = new OdbcParameter(
            "Description", OdbcType.VarChar, 11, 
            ParameterDirection.Output, true, 0, 0, "Description",
            DataRowVersion.Current, "garden hose");
        Console.WriteLine(parameter.ToString());
    }