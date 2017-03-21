 Public Sub CreateMyOleDbCommand()
     Dim queryString As String = "SELECT * FROM Categories ORDER BY CategoryID"
     Dim command As New OleDbCommand(queryString)
     command.CommandTimeout = 20
 End Sub