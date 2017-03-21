    public void CreateSqlParameter() 
    {
        SqlParameter parameter = new SqlParameter(
            "@Description", SqlDbType.VarChar);
        parameter.IsNullable = true;
        parameter.SourceColumn = "Description";
        parameter.SourceVersion = DataRowVersion.Current;
        parameter.Direction = ParameterDirection.Output;
    }