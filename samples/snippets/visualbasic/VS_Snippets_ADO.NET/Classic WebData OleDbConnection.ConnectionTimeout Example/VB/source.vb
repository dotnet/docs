Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    ' The connectionString argument contains the Connect Timeout 
    ' keywords, as follows: "... ;Connect Timeout=30;"
    Public Sub InsertRow(ByVal connectionString As String, _
        ByVal insertSQL As String)

        Using connection As New OleDbConnection(connectionString)
            ' The insertSQL string contains a SQL statement that
            ' inserts a new row in the source table.
            Dim command As New OleDbCommand(insertSQL)

            ' Set the Connection to the new OleDbConnection.
            command.Connection = connection

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
