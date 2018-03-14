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
        SqlParameter parameter = new SqlParameter("@Price", SqlDbType.Decimal);
        parameter.Value = 3.1416;
        parameter.Precision = 8;
        parameter.Scale = 4;

        command.Parameters.Add(parameter);
    }
    // </Snippet1>
}
