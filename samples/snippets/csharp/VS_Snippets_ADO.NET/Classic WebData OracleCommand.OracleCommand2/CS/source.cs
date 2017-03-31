using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 public void CreateOracleCommand() 
 {
    OracleConnection connection = new OracleConnection("Data Source=Oracle8i;Integrated Security=yes");
    string queryString = "SELECT * FROM Emp ORDER BY EmpNo";
    OracleCommand command = new OracleCommand(queryString, connection);
 }
// </Snippet1>

}
