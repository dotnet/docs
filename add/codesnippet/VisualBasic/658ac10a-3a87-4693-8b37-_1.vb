    Private Function GetCustomerData(ByVal dataTableName As String, _
        ByVal connectionString As String) As DataTable

        Dim table As DataTable = New DataTable(dataTableName)

        Using connection As SqlConnection = New SqlConnection(connectionString)

            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
               "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", _
               connection)

            Dim mapping As DataTableMapping = adapter.TableMappings.Add( _
               "Table", "Customers")
            mapping.ColumnMappings.Add("CompanyName", "Name")
            mapping.ColumnMappings.Add("ContactName", "Contact")

            connection.Open()

            adapter.FillSchema(table, SchemaType.Mapped)
            adapter.Fill(table)
            Return table
        End Using
    End Function