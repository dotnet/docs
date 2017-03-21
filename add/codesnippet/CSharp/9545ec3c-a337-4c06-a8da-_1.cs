
 public void CreateOleDbParameter() 
 {
    OleDbParameter parameter = new OleDbParameter("Description",OleDbType.VarChar);
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }