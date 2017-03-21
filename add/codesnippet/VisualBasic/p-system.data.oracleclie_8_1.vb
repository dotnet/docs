Public Sub CreateOracleDbParameter()
    Dim parameter As New OracleParameter()
    parameter.ParameterName = "pDName"
    parameter.DbType = DbType.String
    parameter.Value = "ENGINEERING"
    parameter.SourceColumn = "DName"
End Sub 
