    static void CreateSqlParameterNullable()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;
    }