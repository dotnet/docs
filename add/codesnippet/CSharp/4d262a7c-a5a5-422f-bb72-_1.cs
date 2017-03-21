public void CreateOracleParamColl() {
    OracleCommand command = new OracleCommand( 
        "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection);
    OracleParameterCollection paramCollection = command.Parameters;
    object parameter = new OracleParameter("pEmpNo", OracleType.Number);
    int pIndex = paramCollection.Add(parameter);
 }