    private static void AddSqlParameter(SqlCommand command)
    {
        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@Description";
        parameter.IsNullable = true;
        parameter.DbType = DbType.String;
        parameter.Direction = ParameterDirection.Output;

        command.Parameters.Add(parameter);
    }