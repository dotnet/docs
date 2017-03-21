 public void CreateOracleParameter() 
 {
    OracleParameter parameter = new OracleParameter("DName",OracleType.VarChar);
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 14;
 }