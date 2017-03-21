    public void CreateParameters() 
    {
        OleDbCommand command = new OleDbCommand(
            "SELECT * FROM Customers WHERE CustomerID = ?", connection);
        OleDbParameterCollection paramCollection = command.Parameters;
        OleDbParameter myParm = paramCollection.Add(
            new OleDbParameter("CustomerID", OleDbType.VarChar));
    }