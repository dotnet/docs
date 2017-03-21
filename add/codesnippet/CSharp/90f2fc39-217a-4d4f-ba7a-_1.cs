    private static void AddSqlParameter(SqlCommand command)
    {
        SqlParameter parameter = new SqlParameter("@Description", 
            SqlDbType.VarChar, 88, "Description");
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;

        command.Parameters.Add(parameter);
    }