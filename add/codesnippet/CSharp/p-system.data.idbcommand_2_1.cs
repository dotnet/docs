 public void CreateOleDbCommand() 
 {
    OleDbCommand command = new OleDbCommand();
    command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID;";
    command.CommandType = CommandType.Text;
 }