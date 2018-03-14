Imports System.Data.Odbc

Module Module1

    Sub Main()
        Dim connectionString As String
        connectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
        Call InsertRow(connectionString)
    End Sub

    ' <Snippet1>
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
    ' </Snippet1>

End Module