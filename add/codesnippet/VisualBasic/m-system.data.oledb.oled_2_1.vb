Public Sub CreateMyOleDbDataReader(queryString As String, _
    connectionString As String)
    Dim connection As New OleDbConnection(connectionString)
    Dim command As New OleDbCommand(queryString, connection)
    connection.Open()
    Dim reader As OleDbDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
    While reader.Read()
        Console.WriteLine(reader.GetString(0))
    End While
    reader.Close()
    'Implicitly closes the connection because CommandBehavior.CloseConnection was specified.
 End Sub
