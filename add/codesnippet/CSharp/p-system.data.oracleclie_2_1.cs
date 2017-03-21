 public void CreateOracleCommand() 
 {
    OracleCommand command = new OracleCommand();
    command.CommandText = "SELECT * FROM Emp ORDER BY EmpNo";
    command.CommandType = CommandType.Text;
 }