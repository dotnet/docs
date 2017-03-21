    Public Function GetSchemaTable(ByVal connectionString As String) _
        As DataTable

        Using connection As New OleDbConnection(connectionString)
            connection.Open()

            Dim schemaTable As DataTable = _
                connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
                New Object() {Nothing, Nothing, Nothing, "TABLE"})
            Return schemaTable
        End Using
    End Function