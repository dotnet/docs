    Public Sub CreateOracleCommand(ByVal myExecuteQuery As String, _
    ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(myExecuteQuery, connection)
            command.Connection.Open()
            command.ExecuteNonQuery()
        End Using
    End Sub