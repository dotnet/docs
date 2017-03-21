 public void CreateOleDbCommand() 
 {
    string queryString = "SELECT * FROM Categories ORDER BY CategoryID";
    OleDbCommand command = new OleDbCommand(queryString);
    command.Connection = new OleDbConnection
       ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND_RW.MDB");
    command.CommandTimeout = 20;
 }