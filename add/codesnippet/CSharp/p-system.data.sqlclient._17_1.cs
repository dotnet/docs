    static void CreateSqlParameterVersion()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.Value = "garden hose";
    }