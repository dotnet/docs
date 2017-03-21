    public void CreateOracleParamColl(OracleConnection connection) 
    {
        OracleCommand command = new OracleCommand(
            "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection);
        OracleParameterCollection paramCollection = command.Parameters;
        OracleParameter parameter = paramCollection.Add(
            "pEmpNo", OracleType.Number, 5, "EmpNo");
    }