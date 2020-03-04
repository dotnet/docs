using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;

// <Snippet1>
    public void CreateSqlCommand(SqlConnection myConnection,
        string queryString, SqlParameter[] paramArray) 
    {
        SqlCommand command = new SqlCommand(queryString, myConnection);
        command.CommandText = 
            "SELECT CustomerID, CompanyName FROM Customers " 
            + "WHERE Country = @Country AND City = @City";    
        command.Parameters.AddRange(paramArray);

        string message = "";
        for (int i = 0; i < command.Parameters.Count; i++) 
        {
            message += command.Parameters[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }
// </Snippet1>
}
