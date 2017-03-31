using System;
using System.Data;
using System.Data.SqlClient;

public class Sample
{

    // <Snippet1>
    public void CreateSqlCommand(
        string queryString, SqlConnection connection) 
    {
        SqlCommand command = new 
            SqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteScalar();
        connection.Close();
    }
    // </Snippet1>

}