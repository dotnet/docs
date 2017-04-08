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
        SqlParameter parameter = new SqlParameter("@Description", 
            SqlDbType.VarChar, 88, "Description");
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;

        command.Parameters.Add(parameter);
    }
    // </Snippet1>
}
