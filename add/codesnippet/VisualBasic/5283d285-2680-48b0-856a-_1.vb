    Private Function GetCustomerData(ByVal dataSetName As String, _
        ByVal connectionString As String) As DataSet

        Dim dataSet As DataSet = New DataSet(dataSetName)

        Using connection As SqlConnection = New SqlConnection(connectionString)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
               "SELECT CustomerID, CompanyName, ContactName FROM dbo.Customers", _
               connection)

            Dim mapping As DataTableMapping = adapter.TableMappings.Add( _
               "Table", "Customers")
            mapping.ColumnMappings.Add("CompanyName", "Name")
            mapping.ColumnMappings.Add("ContactName", "Contact")

            connection.Open()

            adapter.FillSchema(dataSet, SchemaType.Mapped)
            adapter.Fill(dataSet)
            Return dataSet
        End Using
    End Function