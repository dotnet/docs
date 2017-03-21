 public void CreateOracleCommand() 
 {
    OracleConnection connection = new OracleConnection("Data Source=Oracle8i;Integrated Security=yes");
    string queryString = "SELECT * FROM Emp ORDER BY EmpNo";
    OracleCommand command = new OracleCommand(queryString, connection);
 }