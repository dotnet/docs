    Public Sub CreateCommand(ByVal queryString As String, _
      ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim command As New SqlCommand(queryString, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                Console.WriteLine("{0}", reader(0))
            End While
        End Using
    End Sub