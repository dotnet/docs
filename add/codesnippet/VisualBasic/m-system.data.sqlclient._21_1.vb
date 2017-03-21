    Public Sub CreateCommand()
        Dim queryString As String = "SELECT * FROM Categories ORDER BY CategoryID"
        Dim command As New SqlCommand(queryString)
        command.CommandTimeout = 15
        command.CommandType = CommandType.Text
    End Sub 