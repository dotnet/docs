        static private DataSet CreateCommandAndUpdate(
            string connectionString,
            string queryString)
        {
            DataSet dataSet = new DataSet();

            using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataAdapter adapter =
                    new OleDbDataAdapter();
                adapter.SelectCommand =
                    new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder =
                    new OleDbCommandBuilder(adapter);

                adapter.Fill(dataSet);

                // Code to modify data in the DataSet here.

                // Without the OleDbCommandBuilder, this line would fail.
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dataSet);
            }
            return dataSet;
        }