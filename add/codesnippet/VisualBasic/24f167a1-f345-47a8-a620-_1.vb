 Public Sub CreateOracleCommand()
     Dim connection As New OracleConnection _
        ("Data Source=Oracle8i;Integrated Security=yes")
     Dim queryString As String = _
        "SELECT * FROM Emp ORDER BY EmpNo"
     Dim command As New OracleCommand(queryString, connection)
 End Sub