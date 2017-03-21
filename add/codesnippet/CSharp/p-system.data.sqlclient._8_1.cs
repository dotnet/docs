 public void CreateSqlCommand() 
 {
    SqlCommand command = new SqlCommand();
    command.CommandTimeout = 15;
    command.CommandType = CommandType.Text;
 }