 Public Sub CreateMyOleDbCommand()
     Dim command As New OleDbCommand()
     command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID"
     command.CommandTimeout = 20
 End Sub