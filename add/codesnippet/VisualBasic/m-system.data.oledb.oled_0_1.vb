    Public Sub CreateCommand _
        (ByVal queryString As String, ByVal connection As OleDbConnection)

        Dim command As New OleDbCommand(queryString, connection)
        command.Connection.Open()
        command.ExecuteReader()
        command.Cancel()
    End Sub