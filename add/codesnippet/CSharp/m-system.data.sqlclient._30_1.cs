    public static void ShowSqlException(string connectionString)
    {
        string queryString = "EXECUTE NonExistantStoredProcedure";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                DisplaySqlErrors(ex);
            }
        }
    }

    private static void DisplaySqlErrors(SqlException exception)
    {
        for (int i = 0; i < exception.Errors.Count; i++)
        {
            Console.WriteLine("Index #" + i + "\n" +
                "Error: " + exception.Errors[i].ToString() + "\n");
        }
        Console.ReadLine();
    }