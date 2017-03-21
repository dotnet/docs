    static void CreateSqlParameterSourceVersion()
    {
        SqlParameter parameter = new SqlParameter("Description", SqlDbType.VarChar, 88);
        parameter.SourceColumn = "Description";
        parameter.SourceVersion = DataRowVersion.Current;
    }