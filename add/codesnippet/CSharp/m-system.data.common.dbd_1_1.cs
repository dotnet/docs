        public DataTable CreateCmdsAndUpdate(string connectionString,
            string queryString) 
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                connection.Open();

                DataTable customers = new DataTable();
                adapter.Fill(customers);

                // code to modify data in DataTable here

                adapter.Update(customers);

                return customers;
            }
        }
