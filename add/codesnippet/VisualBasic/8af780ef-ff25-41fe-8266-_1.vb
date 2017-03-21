    Public Sub CreateParamCollection(connection As OdbcConnection)
      Dim command As OdbcCommand = New OdbcCommand( _
        "SELECT * FROM Customers WHERE CustomerID = ?", connection)
      Dim paramCollection As OdbcParameterCollection = command.Parameters
      Dim paramObject As Object = New OdbcParameter( _
        "CustomerID", OdbcType.VarChar)
      Dim paramIndex As Integer = paramCollection.Add(paramObject)
    End Sub 