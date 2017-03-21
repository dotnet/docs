public void CreateCommand() 
 {
    SqlCommand command = new SqlCommand();
    command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID";
    command.CommandTimeout = 15;
    command.CommandType = CommandType.Text;
 }