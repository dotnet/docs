    public void CreateSqlParameter() 
    {
        SqlParameter parameter = new SqlParameter(
            "@Description", SqlDbType.VarChar);
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;
        parameter.SourceColumn = "Description";
    }