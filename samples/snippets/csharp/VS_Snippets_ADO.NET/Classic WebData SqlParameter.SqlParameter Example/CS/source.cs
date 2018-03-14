using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
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
    // </Snippet1>
}
