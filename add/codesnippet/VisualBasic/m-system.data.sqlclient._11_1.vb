    Private Sub ReadOrderData(ByVal connectionString As String)
        Dim queryString As String = _
            "SELECT OrderID, CustomerID FROM dbo.Orders;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()

            Dim reader As SqlDataReader = command.ExecuteReader()

            ' Call Read before accessing data.
            While reader.Read()
                Console.WriteLine(String.Format("{0}, {1}", _
                    reader(0), reader(1)))
            End While

            ' Call Close when done reading.
            reader.Close()
        End Using
    End Sub