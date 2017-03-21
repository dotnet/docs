
 public void CreateOdbcParameter() 
 {
    OdbcParameter parameter = new OdbcParameter("Description",OdbcType.VarChar);
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }