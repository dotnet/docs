    static void CreateSqlParameterOffset()
    {
        SqlParameter parameter = new SqlParameter("pDName", SqlDbType.VarChar);
        parameter.IsNullable = true;
        parameter.Offset = 3;
    }