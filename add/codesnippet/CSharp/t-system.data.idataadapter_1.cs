private static DataSet SelectRows(DataSet dataset,
    string connectionString,string queryString) 
{
    using (SqlConnection connection = 
        new SqlConnection(connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(
            queryString, connection);
        adapter.Fill(dataset);
        return dataset;
    }
}
