 public void CreateOdbcParameter() 
 {
    OdbcParameter parameter = new OdbcParameter();
    parameter.ParameterName = "Description";
    parameter.OdbcType = OdbcType.VarChar;
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }