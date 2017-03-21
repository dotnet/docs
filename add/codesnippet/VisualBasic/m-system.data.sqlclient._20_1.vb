    Private Sub OpenSqlConnection(ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion)
            Console.WriteLine("State: {0}", connection.State)
        End Using
    End Sub