    Public Function CreateCommandAndUpdate( _
        ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Dim dataSet As DataSet = New DataSet

        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim adapter As New OleDbDataAdapter()

            adapter.SelectCommand = New OleDbCommand( _
                queryString, connection)

            Dim builder As OleDbCommandBuilder = _
                New OleDbCommandBuilder(adapter)

            adapter.Fill(dataSet)

            ' Code to modify the data in the DataSet here. 

            ' Without the OleDbCommandBuilder this line would fail.
            builder.GetUpdateCommand()
            adapter.Update(dataSet)
        End Using
        Return dataSet
    End Function