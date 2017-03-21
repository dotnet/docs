    public void CreateParamCollection() 
    {
        OdbcCommand command = new OdbcCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OdbcParameterCollection paramCollection = command.Parameters;
        object paramObject = new OdbcParameter(
            "CustomerID", OdbcType.VarChar);
        int paramIndex = paramCollection.Add(paramObject);
    }