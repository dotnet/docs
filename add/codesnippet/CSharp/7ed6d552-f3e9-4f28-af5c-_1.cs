
 public void CreateOdbcParameter() 
 {
    OdbcParameter parameter = new OdbcParameter("Description",OdbcType.VarChar,88);
    parameter.Direction = ParameterDirection.Output;
 }