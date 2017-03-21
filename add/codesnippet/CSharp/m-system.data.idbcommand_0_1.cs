    public void CreateSqlCommand(
        string queryString, SqlConnection connection) 
    {
        SqlCommand command = new 
            SqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteScalar();
        connection.Close();
    }