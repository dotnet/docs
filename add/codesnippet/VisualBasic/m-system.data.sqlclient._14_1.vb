    Public Sub CreateCommand(ByVal queryString As String, _
      ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()
            Dim reader As SqlDataReader = _
                command.ExecuteReader(CommandBehavior.CloseConnection)
            While reader.Read()
                Console.WriteLine("{0}", reader(0))
            End While
        End Using
    End Sub