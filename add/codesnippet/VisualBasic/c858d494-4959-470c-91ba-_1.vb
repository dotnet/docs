    Public Sub CreateCommand(ByVal queryString As String, _
      ByVal connectionString As String)
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)

            connection.Open()
            Dim reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                Console.WriteLine(String.Format("{0}, {1}", _
                    reader(0), reader(1)))
            End While
        End Using
    End Sub