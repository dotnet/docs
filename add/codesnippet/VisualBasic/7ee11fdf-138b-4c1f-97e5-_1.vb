    Public Sub CreateOracleParamColl(connection As OracleConnection)
      Dim command As OracleCommand = _
        New OracleCommand("SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection)
      Dim paramCollection As OracleParameterCollection = command.Parameters
      Dim parameter As OracleParameter = _
        paramCollection.Add("pEmpNo", OracleType.Number, 5, "EmpNo")
    End Sub 