    private static void ChangeSqlDatabase(string connectionString)
    {
        // Assumes connectionString represents a valid connection string
        // to the AdventureWorks sample database.
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("Database: {0}", connection.Database);

            connection.ChangeDatabase("Northwind");
            Console.WriteLine("Database: {0}", connection.Database);
        }
    }