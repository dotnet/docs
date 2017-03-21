public void CreateOracleDbParameter() 
 {
    OracleParameter parameter = new OracleParameter();
    parameter.ParameterName = "pDName";
    parameter.DbType = DbType.String;
    parameter.Value = "ENGINEERING";
    parameter.SourceColumn = "DName";
 }
