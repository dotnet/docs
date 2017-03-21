    Public Sub CreateCommand()
        Dim command As New SqlCommand()
        command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID"
        command.CommandTimeout = 15
        command.CommandType = CommandType.Text
    End Sub 