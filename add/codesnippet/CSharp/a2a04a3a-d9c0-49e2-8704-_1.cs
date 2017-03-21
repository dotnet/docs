
 public void CreateOleDbParameter() 
 {
    OleDbParameter parameter = new OleDbParameter(
        "Description",OleDbType.VarChar,
        88,"Description");
    parameter.Direction = ParameterDirection.Output;
 }