    Public Sub ReadMyData(ByVal connectionString As String)
        Dim queryString As String = "SELECT OrderID, CustomerID FROM Orders"
        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)

            connection.Open()

            Dim reader As OleDbDataReader = command.ExecuteReader()
            While reader.Read()
                Console.WriteLine(reader.GetInt32(0).ToString() + ", " _
                   + reader.GetString(1))
            End While

            ' always call Close when done reading.
            reader.Close()
        End Using
    End Sub