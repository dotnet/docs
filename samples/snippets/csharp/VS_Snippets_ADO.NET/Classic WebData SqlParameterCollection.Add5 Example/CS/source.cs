using System;
using System.Data;
using System.Data.SqlClient;

public class Sample
{
// <Snippet1>
  public void AddSqlParameter(SqlCommand cmd) 
  {
    SqlParameter p1 = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 16, "Description");
  }
// </Snippet1>
}