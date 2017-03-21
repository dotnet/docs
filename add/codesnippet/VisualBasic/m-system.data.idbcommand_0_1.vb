Public Sub CreateSqlCommand( _
    queryString As String, connection As SqlConnection)

    Dim command As New SqlCommand(queryString, connection)
    command.Connection.Open()
    command.ExecuteScalar()
    connection.Close()
End Sub