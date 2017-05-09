using System;
using System.Data;
using System.Data.SqlClient;

public class Sample
{
    // <Snippet1>
    public void AddSqlParameter(SqlCommand command) 
    {
        SqlParameter param = command.Parameters.Add(
            "@Description", SqlDbType.NVarChar);
        param.Size = 16;
        param.Value = "Beverages";
    }
    // </Snippet1>
}