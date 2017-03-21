    public void CreateSqlParameter() 
    {
        SqlParameter parameter = new SqlParameter(
            "@Description", SqlDbType.VarChar);
        parameter.Value = "garden hose";
        parameter.Size = 11;
    }