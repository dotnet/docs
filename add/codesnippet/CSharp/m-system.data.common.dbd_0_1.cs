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

                //Insert new records from DataSet
                DataRow[] rows = customers.Tables[0].Select(
                    null, null, DataViewRowState.Added);
                adapter.Update(rows);

                return customers;
            }
        }