 public void CreateOracleParameter() 
 {
    OracleParameter parameter = new OracleParameter("DName",OracleType.VarChar,
                 14,"DName");
    parameter.Direction = ParameterDirection.Output;
 }