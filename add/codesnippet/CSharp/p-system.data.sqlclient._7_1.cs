    private static void OpenSqlConnection(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("WorkstationId: {0}", connection.WorkstationId);
        }
    }