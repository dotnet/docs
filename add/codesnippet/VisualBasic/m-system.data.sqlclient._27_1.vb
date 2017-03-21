    Private Sub ReadGetOrdinal(ByVal connectionString As String)
        Dim queryString As String = _
           "SELECT DISTINCT CustomerID FROM dbo.Orders;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Call GetOrdinal and assign value to variable.
            Dim customerID As Integer = reader.GetOrdinal("CustomerID")

            ' Use variable with GetString inside of loop.
            While reader.Read()
                Console.WriteLine("CustomerID={0}", reader.GetString(customerID))
            End While

            ' Call Close when done reading.
            reader.Close()
        End Using
    End Sub