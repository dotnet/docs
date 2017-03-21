public void CreateCommand() 
 {
    string queryString = "SELECT * FROM Categories ORDER BY CategoryID";
    SqlCommand command = new SqlCommand(queryString);
    command.CommandTimeout = 15;
    command.CommandType = CommandType.Text;
 }