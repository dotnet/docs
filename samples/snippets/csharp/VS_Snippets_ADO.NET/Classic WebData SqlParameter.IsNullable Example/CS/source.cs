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
        SqlParameter parameter = new SqlParameter(
            "@Description", SqlDbType.VarChar);
        parameter.Value = paramValue;
        parameter.IsNullable = true;
        command.Parameters.Add(parameter);
    }

private static void SetParameterToNull(IDataParameter parameter)
{
    if (parameter.IsNullable)
    {
        parameter.Value = DBNull.Value;
    }
    else
    {
        throw new ArgumentException("Parameter provided is not nullable", "parameter");
    }
}

    // </Snippet1>
}
