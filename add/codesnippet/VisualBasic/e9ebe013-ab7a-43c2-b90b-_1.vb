    Public Sub CreateOdbcParamColl(connection As OdbcConnection)
      Dim command As OdbcCommand = New OdbcCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OdbcParameterCollection = _
        command.Parameters
      Dim parameter As OdbcParameter = _
        paramCollection.Add("CustomerID", OdbcType.VarChar, 5)
    End Sub 'CreateOdbcParamColl