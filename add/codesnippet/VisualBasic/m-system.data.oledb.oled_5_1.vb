    Private Sub CreateOleDbCommand( _
        ByVal queryString As String, ByVal connectionString As String)
        Using connection As New OleDbConnection(connectionString)
            connection.Open()
            Dim command As New OleDbCommand(queryString, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub