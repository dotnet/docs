    static void CreateSqlParameterSourceColumn()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.SourceColumn = "Description";
    }