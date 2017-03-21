    public void AddSqlParameter(SqlCommand command) 
    {
        SqlParameter param = command.Parameters.Add(
            "@Description", SqlDbType.NVarChar);
        param.Size = 16;
        param.Value = "Beverages";
    }