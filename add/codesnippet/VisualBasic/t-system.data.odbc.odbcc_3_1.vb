    Private Sub InsertRow(ByVal connectionString As String)

        Dim queryString As String = _
            "INSERT INTO Customers (CustomerID, CompanyName) Values('NWIND', 'Northwind Traders')"
        Dim command As New OdbcCommand(queryString)

        Using connection As New OdbcConnection(connectionString)
            command.Connection = connection
            connection.Open()
            command.ExecuteNonQuery()

            ' The connection is automatically closed at 
            ' the end of the Using block.
        End Using
    End Sub