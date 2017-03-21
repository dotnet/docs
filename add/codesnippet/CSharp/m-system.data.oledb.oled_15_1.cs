    static void OpenConnection(string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection.State: {0}", connection.State);

                connection.Close();
                OleDbConnection.ReleaseObjectPool();
                Console.WriteLine("Connection.State: {0}", connection.State);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // The connection is automatically closed when the
            // code exits the using block.
        }
    }