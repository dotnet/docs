Public Sub CreateOracleCommand(myScalarQuery As String, connection As OracleConnection)
    Dim command As New OracleCommand(myScalarQuery, connection)
    command.Connection.Open()
    command.ExecuteScalar()
    connection.Close()
End Sub 'CreateOracleCommand