using System;
using System.Data;
using System.Data.SqlClient;

public class Sample
{
    // <Snippet1>
    public void AddSqlParameter(SqlCommand command) 
    {
        SqlParameter param = new SqlParameter(
            "@Description", SqlDbType.NVarChar, 16);
        param.Value = "Beverages";
        command.Parameters.Add(param);
    }
    // </Snippet1>
}