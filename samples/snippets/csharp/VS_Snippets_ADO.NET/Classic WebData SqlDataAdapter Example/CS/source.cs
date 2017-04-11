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
private static DataSet SelectRows(DataSet dataset,
    string connectionString,string queryString) 
{
    using (SqlConnection connection = 
        new SqlConnection(connectionString))
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(
            queryString, connection);
        adapter.Fill(dataset);
        return dataset;
    }
}

// </Snippet1>

}
