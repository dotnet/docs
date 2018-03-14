using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
    }
    // <Snippet1>
    private static void AddSqlParameter(SqlCommand command, 
        string paramValue)
    {
        SqlParameter parameter = new SqlParameter("@Description", 
            SqlDbType.VarChar, 88);
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;
        parameter.Value = paramValue;

        command.Parameters.Add(parameter);
    }
    // </Snippet1>
}
