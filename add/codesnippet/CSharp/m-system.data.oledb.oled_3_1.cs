 public void CreateOleDbParameter() 
 {
    OleDbParameter parameter = new OleDbParameter();
    parameter.ParameterName = "Description";
    parameter.OleDbType = OleDbType.VarChar;
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }