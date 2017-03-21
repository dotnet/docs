 Public Sub CreateOleDbCommand()
     Dim queryString As String = _
        "SELECT * FROM Categories ORDER BY CategoryID"
     Dim command As New OleDbCommand(queryString)
     command.Connection = New OleDbConnection _
        ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND_RW.MDB")
     command.CommandTimeout = 20
 End Sub