 Public Sub CreateOracleCommand()
     Dim queryString As String = _
        "SELECT * FROM Emp ORDER BY EmpNo"
     Dim command As New OracleCommand(queryString)
     command.CommandType = CommandType.Text
 End Sub