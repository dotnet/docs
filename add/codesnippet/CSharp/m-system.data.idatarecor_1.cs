    public static void ReadData(string connectionString)
    {
        string queryString = "SELECT DISTINCT CustomerID FROM Orders";

        using (OdbcConnection connection = new OdbcConnection(connectionString))
        {
            OdbcCommand command = new OdbcCommand(queryString, connection);

            connection.Open();
            OdbcDataReader reader = command.ExecuteReader();

            int customerID = reader.GetOrdinal("CustomerID");

            while (reader.Read())
            {
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID));
            }

            // Call Close when done reading.
            reader.Close();
        }
    }