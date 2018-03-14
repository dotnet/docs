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
            SqlDbType.VarChar, 11, ParameterDirection.Input,
            true, 0, 0, "Description", DataRowVersion.Current, 
            "garden hose");
        parameter.IsNullable = true;

        command.Parameters.Add(parameter);
    }
    // </Snippet1>
}
