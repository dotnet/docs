    public void CreateMyOleDbCommand(string queryString, 
        OleDbConnection connection) 
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteScalar();
        connection.Close();
    }