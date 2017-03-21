    private static void AddSqlParameter(SqlCommand command)
    {
        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@Description";
        parameter.IsNullable = true;
        parameter.SqlDbType = SqlDbType.VarChar;
        parameter.Direction = ParameterDirection.Output;
        parameter.Size = 88;

        command.Parameters.Add(parameter);
    }