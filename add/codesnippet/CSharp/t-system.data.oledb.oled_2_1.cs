    public static void ReadData(string connectionString, string queryString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString());
            }
            reader.Close();
        }
    }