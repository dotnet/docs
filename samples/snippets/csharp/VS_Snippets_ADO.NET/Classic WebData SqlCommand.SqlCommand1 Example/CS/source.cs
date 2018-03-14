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
public void CreateCommand() 
 {
    string queryString = "SELECT * FROM Categories ORDER BY CategoryID";
    SqlCommand command = new SqlCommand(queryString);
    command.CommandTimeout = 15;
    command.CommandType = CommandType.Text;
 }
// </Snippet1>

}
