    public void CreateOracleCommand(string connectionString)
    {
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            OracleTransaction transaction = connection.BeginTransaction();
            string queryString = "SELECT * FROM Emp ORDER BY EmpNo";
            OracleCommand command = new OracleCommand(queryString, connection, transaction);
            command.CommandType = CommandType.Text;
        }
    }