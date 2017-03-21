    public static void ReadData(string connectionString)
    {
        string queryString = "SELECT DISTINCT CustomerID FROM Orders";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);

            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            int customerID = reader.GetOrdinal("CustomerID");

            while (reader.Read())
            {
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID));
            }
            reader.Close();
        }
    }