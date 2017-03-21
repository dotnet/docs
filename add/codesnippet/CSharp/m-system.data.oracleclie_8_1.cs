    public void CreateOracleCommand(string myExecuteQuery, string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            OracleCommand command = new OracleCommand(myExecuteQuery, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }