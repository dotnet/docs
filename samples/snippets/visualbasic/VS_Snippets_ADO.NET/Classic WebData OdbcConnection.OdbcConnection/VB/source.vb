Imports System.Data.Odbc

Module Module1

    Sub Main()
        Call CreateOdbcConnection()
    End Sub

    ' <Snippet1>
    Private Sub CreateOdbcConnection()

        Using connection As New OdbcConnection
            connection.ConnectionString = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
            connection.Open()
        End Using

    End Sub
    ' </Snippet1>

End Module