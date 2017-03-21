Public Sub CreateMyOleDbCommand(queryString As String, _
    connection As OleDbConnection)
    Dim command As New OleDbCommand(queryString, connection)
    command.Connection.Open()
    command.ExecuteScalar()
    connection.Close()
End Sub 