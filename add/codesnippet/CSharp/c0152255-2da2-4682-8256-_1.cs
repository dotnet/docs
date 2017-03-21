    public void AddSqlParameter(SqlCommand command) 
    {
        SqlParameter param = new SqlParameter(
            "@Description", SqlDbType.NVarChar, 16);
        param.Value = "Beverages";
        command.Parameters.Add(param);
    }