 public void CreateOracleParameter() 
 {
    OracleParameter parameter = new OracleParameter("DName",OracleType.VarChar,14);
    parameter.Direction = ParameterDirection.Output;
 }