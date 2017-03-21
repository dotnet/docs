    Public Sub CreateOracleParamColl(connection As OracleConnection)
      Dim command As OracleCommand = New OracleCommand( _
        "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection)
      Dim paramCollection As OracleParameterCollection = command.Parameters
      Dim parameter As OracleParameter = paramCollection.Add( _
        "pEmpNo", OracleType.Number, 4)
    End Sub 