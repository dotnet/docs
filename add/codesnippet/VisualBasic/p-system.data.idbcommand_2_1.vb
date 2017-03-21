 Public Sub CreateOleDbCommand()
     Dim command As New OleDbCommand()
     command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID;"
     command.CommandType = CommandType.Text
 End Sub