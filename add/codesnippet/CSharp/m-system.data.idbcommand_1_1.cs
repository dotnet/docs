        static private void CreateOleDbCommand(
            string queryString, string connectionString)
        {
            using (OleDbConnection connection = new 
                       OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command = new 
                    OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }