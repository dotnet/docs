    private static void CreateCommand(string queryString,
        string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}", reader[0]));
            }
        }
    }