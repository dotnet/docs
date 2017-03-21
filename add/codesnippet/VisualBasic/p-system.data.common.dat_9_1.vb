    ' Assumes a valid connection string to an Access database.
    Private Sub CreateOleDbDataAdapter(ByVal connectionString As String)
        Dim adapter As New OleDbDataAdapter()
        adapter.SelectCommand = _
           New OleDbCommand("SELECT * FROM Categories ORDER BY CategoryID")
        adapter.SelectCommand.Connection = New OleDbConnection _
           (connectionString)
        adapter.MissingMappingAction = MissingMappingAction.Error
        adapter.MissingSchemaAction = MissingSchemaAction.Error
    End Sub