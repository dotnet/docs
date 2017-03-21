    Public Sub CreateParameters(connection As OleDbConnection)
      Dim command As OleDbCommand = New OleDbCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OleDbParameterCollection = command.Parameters
      Dim myParm As OleDbParameter = paramCollection.Add( _
        New OleDbParameter("CustomerID", OleDbType.VarChar))
    End Sub 