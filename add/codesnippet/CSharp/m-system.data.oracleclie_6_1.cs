    public void CreateOracleCommand(string queryString, string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(queryString, connection);
            command.Connection.Open();
            command.ExecuteReader();
            command.Cancel();
        }
    }