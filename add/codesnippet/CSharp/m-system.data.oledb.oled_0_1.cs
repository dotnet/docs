    public void CreateCommand(string queryString, OleDbConnection connection)
    {
        OleDbCommand command = new OleDbCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteReader();
        command.Cancel();
    }