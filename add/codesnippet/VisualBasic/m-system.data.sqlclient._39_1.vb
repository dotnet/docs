 Public Sub CreateSqlCommand()
     Dim command As New SqlCommand()
     command.CommandTimeout = 15
     command.CommandType = CommandType.Text
 End Sub