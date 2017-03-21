 public void CreateOracleCommand() 
 {
    string queryString = "SELECT * FROM Emp ORDER BY EmpNo";
    OracleCommand command = new OracleCommand(queryString);
    command.CommandType = CommandType.Text;
 }