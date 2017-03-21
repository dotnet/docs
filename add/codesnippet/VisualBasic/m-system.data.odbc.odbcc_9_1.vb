    Private Sub CreateOdbcConnection()

        Using connection As New OdbcConnection
            connection.ConnectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
            connection.Open()
        End Using

    End Sub