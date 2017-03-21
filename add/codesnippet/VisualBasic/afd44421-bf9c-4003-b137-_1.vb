    Public Sub CreateParameterCollection(connection As OdbcConnection)
      Dim command As OdbcCommand = New OdbcCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OdbcParameterCollection = command.Parameters
      Dim parameter As OdbcParameter = paramCollection.Add( _
        "CustomerID", OdbcType.VarChar, 5, "CustomerID")
    End Sub