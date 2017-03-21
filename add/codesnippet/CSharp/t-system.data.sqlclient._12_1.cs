        public static DataSet SelectSqlRows(string connectionString,
            string queryString, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(queryString, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                connection.Open();

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);

                //code to modify data in DataSet here

                builder.GetUpdateCommand();

                //Without the SqlCommandBuilder this line would fail
                adapter.Update(dataSet, tableName);

                return dataSet;
            }
        }