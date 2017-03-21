    Public Sub CreateMyOracleDataReader(ByVal queryString As String, _
    ByVal connectionString As String)
        Using connection As New OracleConnection(connectionString)
            Dim command As New OracleCommand(queryString, connection)
            connection.Open()

            'Implicitly closes the connection because  
            ' CommandBehavior.CloseConnectionwas specified.
            Dim reader As OracleDataReader = _
                command.ExecuteReader(CommandBehavior.CloseConnection)
            While reader.Read()
                Console.WriteLine(reader.GetValue(0))
            End While
            reader.Close()
        End Using
    End Sub