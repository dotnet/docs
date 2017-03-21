    Public Function SelectOdbcSrvRows( _
        ByVal connectionString As String, ByVal queryString As String, _
        ByVal tableName As String) As DataSet

        Dim dataSet As DataSet = New DataSet

        Using connection As New OdbcConnection(connectionString)
            Dim adapter As New OdbcDataAdapter()
            adapter.SelectCommand = _
                New OdbcCommand(queryString, connection)
            Dim builder As OdbcCommandBuilder = _
                New OdbcCommandBuilder(adapter)

            connection.Open()

            adapter.Fill(dataSet, tableName)

            ' Code to modify data in DataSet here 

            ' Without the OdbcCommandBuilder this line would fail.
            adapter.Update(dataSet, tableName)
        End Using

        Return dataSet
    End Function