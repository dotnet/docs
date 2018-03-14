Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Odbc

Module Module1

    Sub Main()
        'Dim connectionString As String = _
        '"Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
    End Sub

    ' <Snippet1>
    Public Sub InsertRow(ByVal connectionString As String, _
        ByVal insertSQL As String)

        Using connection As New OdbcConnection(connectionString)
            ' The insertSQL string contains a SQL statement that
            ' inserts a new row in the source table.
            Dim command As New OdbcCommand(insertSQL, connection)

            ' Open the connection and execute the insert command.
            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            ' The connection is automatically closed when the
            ' code exits the Using block.
        End Using
    End Sub
    ' </Snippet1>

End Module
