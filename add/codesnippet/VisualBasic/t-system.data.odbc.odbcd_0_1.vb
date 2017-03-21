    Public Sub ReadData(ByVal connectionString As String)
        Dim queryString As String = "SELECT DISTINCT CustomerID FROM Orders"

        Using connection As New OdbcConnection(connectionString)
            Dim command As New OdbcCommand(queryString, connection)

            connection.Open()

            Dim reader As OdbcDataReader = command.ExecuteReader()

            While reader.Read()
                Console.WriteLine("CustomerID={0}", reader(0).ToString)
            End While

            ' Call Close when done reading.
            reader.Close()
        End Using
    End Sub