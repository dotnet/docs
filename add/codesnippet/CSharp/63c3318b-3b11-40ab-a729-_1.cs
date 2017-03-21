public void CreateOracleParameter() 
 {
    OracleParameter parameter = new OracleParameter(
        "DName",OracleType.VarChar,
        11,ParameterDirection.Output,true,0,0,"DName",
        DataRowVersion.Current,"ENGINEERING");
    Console.WriteLine(parameter.ToString());
 }