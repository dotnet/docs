 Public Sub CreateOracleCommand()
     Dim command As New OracleCommand()
     command.CommandText = "SELECT * FROM Emp ORDER BY EmpNo"
     command.CommandType = CommandType.Text
 End Sub