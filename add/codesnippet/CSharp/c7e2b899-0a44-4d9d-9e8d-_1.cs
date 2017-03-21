    public static DataSet GetCustomerData(string dataSetName,
        string connectionString)
    {
        DataSet dataSet = new DataSet(dataSetName);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", connection);

            DataTableMapping mapping = adapter.TableMappings.Add("Table", "Customers");
            mapping.ColumnMappings.Add("CompanyName", "Name");
            mapping.ColumnMappings.Add("ContactName", "Contact");

            connection.Open();

            adapter.FillSchema(dataSet, SchemaType.Source, "Customers");
            adapter.Fill(dataSet);

            return dataSet;
        }
    }