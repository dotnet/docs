 public void CreateMyOleDbCommand() 
 {
    OleDbCommand command = new OleDbCommand();
    command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID";
    command.CommandTimeout = 20;
 }