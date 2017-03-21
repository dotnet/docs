    public void CreateParameterCollection(OdbcConnection connection) 
    {
        OdbcCommand command = new OdbcCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OdbcParameterCollection paramCollection = command.Parameters;
        OdbcParameter parameter = paramCollection.Add(
            "CustomerID", OdbcType.VarChar, 5, "CustomerID");
    }