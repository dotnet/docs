    Public Sub CreateMyOracleDataReader(ByVal queryString As String, _
    ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            connection.Open()
            Dim reader As OracleDataReader = command.ExecuteReader()
            Try
                While reader.Read()
                    Console.WriteLine(reader.GetValue(0))
                End While
            Finally
                reader.Close()
            End Try
        End Using
    End Sub