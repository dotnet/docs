        // Assumes a valid connection string to an Access database.
        static void CreateOleDbAdapter(string connectionString)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand =
                new OleDbCommand("SELECT * FROM Categories ORDER BY CategoryID");
            adapter.SelectCommand.Connection =
                new OleDbConnection(connectionString);
            adapter.MissingMappingAction = MissingMappingAction.Error;
            adapter.MissingSchemaAction = MissingSchemaAction.Error;
        }