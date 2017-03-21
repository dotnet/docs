 public void CreateMyOleDbCommand() 
 {
    string queryString = "SELECT * FROM Categories ORDER BY CategoryID";
    OleDbCommand command = new OleDbCommand(queryString);
    command.CommandTimeout = 20;
 }