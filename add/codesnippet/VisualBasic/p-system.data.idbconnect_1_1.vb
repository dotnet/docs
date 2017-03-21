 Public Sub CreateOleDbConnection()
     Dim connection As New OleDbConnection()
     connection.ConnectionString = _
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Northwind.mdb"
     Console.WriteLine("Connection State: " & connection.State.ToString())
 End Sub