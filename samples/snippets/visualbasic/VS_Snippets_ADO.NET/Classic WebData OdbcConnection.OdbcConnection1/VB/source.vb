Imports System.Data.Odbc

Module Module1

    Sub Main()
        Call CreateOdbcConnection()
    End Sub

    ' <Snippet1>
    Private Sub CreateOdbcConnection()
        Dim connectionString As String = "Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"

        Using connection As New OdbcConnection(connectionString)
            connection.Open()
        End Using

    End Sub
    ' </Snippet1>

End Module
