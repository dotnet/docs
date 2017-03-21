    public static DataTable GetCustomerData(string dataSetName,
        string connectionString)
    {
        DataTable table = new DataTable(dataSetName);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", connection);

            DataTableMapping mapping = adapter.TableMappings.Add("Table", "Customers");
            mapping.ColumnMappings.Add("CompanyName", "Name");
            mapping.ColumnMappings.Add("ContactName", "Contact");

            connection.Open();

            adapter.FillSchema(table, SchemaType.Mapped);
            adapter.Fill(table);
            return table;
        }
    }