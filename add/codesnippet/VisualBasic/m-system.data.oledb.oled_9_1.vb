    Public Sub ReadData(ByVal connectionString As String)
        Dim queryString As String = "SELECT DISTINCT CustomerID FROM Orders"

        Using connection As New OleDbConnection(connectionString)
            Dim command As New OleDbCommand(queryString, connection)

            connection.Open()

            Dim reader As OleDbDataReader = command.ExecuteReader()

            Dim customerID As Integer = reader.GetOrdinal("CustomerID")
            While reader.Read()
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID))
            End While
            reader.Close()
        End Using
    End Sub