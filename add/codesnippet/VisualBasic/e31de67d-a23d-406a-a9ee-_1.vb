    Public Sub CreateParameters(connection As OleDbConnection)
      Dim command As OleDbCommand = New OleDbCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OleDbParameterCollection = command.Parameters
      Dim parameter As OleDbParameter = paramCollection.Add( _
        "CustomerID", OleDbType.VarChar, 5, "CustomerID")
    End Sub 