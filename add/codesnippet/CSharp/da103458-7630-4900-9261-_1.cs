    static DataTable GetSchemaTable(string connectionString)
    {
        using (OleDbConnection connection = new 
                   OleDbConnection(connectionString))
        {
            connection.Open();
            DataTable schemaTable = connection.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new object[] { null, null, null, "TABLE" });
            return schemaTable;
        }
    }