public void CreateOracleCommand(string myScalarQuery, OracleConnection connection) 
 {
    OracleCommand command = new OracleCommand(myScalarQuery, connection);
    command.Connection.Open();
    command.ExecuteScalar();
    connection.Close();
 }