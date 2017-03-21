public void CreateMyOleDbDataReader(string queryString,string connectionString) 
{
   OleDbConnection connection = new OleDbConnection(connectionString);
   OleDbCommand command = new OleDbCommand(queryString, connection);
   connection.Open();
   OleDbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
   while(reader.Read()) 
   {
      Console.WriteLine(reader.GetString(0));
   }
   reader.Close();
   //Implicitly closes the connection because CommandBehavior.CloseConnection was specified.
}
