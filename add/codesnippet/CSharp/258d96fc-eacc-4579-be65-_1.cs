
 public void CreateOleDbParameter() 
 {
    OleDbParameter parameter = new OleDbParameter("Description",OleDbType.VarChar,88);
    parameter.Direction = ParameterDirection.Output;
 }