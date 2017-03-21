    public void CreateOracleConnection()
    {
        string connectionString = "Data Source=Oracle8i;Integrated Security=yes";
        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("ServerVersion: " + connection.ServerVersion
                + "\nState: " + connection.State);
        }
    }