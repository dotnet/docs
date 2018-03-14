Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class Sample
' <Snippet1>
Public Sub CreateSqlCommand( _
    queryString As String, connection As SqlConnection)

    Dim command As New SqlCommand(queryString, connection)
    command.Connection.Open()
    command.ExecuteScalar()
    connection.Close()
End Sub
' </Snippet1>

End Class
