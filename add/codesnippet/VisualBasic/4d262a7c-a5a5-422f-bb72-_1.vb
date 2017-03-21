    Public Sub CreateOracleParamColl(connection As OracleConnection)
      Dim command As OracleCommand = New OracleCommand( _
        "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection)
      Dim paramCollection As OracleParameterCollection = command.Parameters
      Dim parameter As Object = New OracleParameter("pEmpNo", OracleType.Number)
      Dim pIndex As Integer = paramCollection.Add(parameter)
    End Sub 