        public DataSet CreateCmdsAndUpdate(string connectionString,
            string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(queryString, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                connection.Open();

                DataSet customers = new DataSet();
                adapter.Fill(customers);

                //code to modify data in dataset here

                adapter.Update(customers);

                return customers;
            }
        }