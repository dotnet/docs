    public void CreateParameters(OleDbConnection connection) 
    {
        OleDbCommand command = new OleDbCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OleDbParameterCollection paramCollection = command.Parameters;
        OleDbParameter parameter = paramCollection.Add(
            "CustomerID", OleDbType.VarChar, 5);
    }