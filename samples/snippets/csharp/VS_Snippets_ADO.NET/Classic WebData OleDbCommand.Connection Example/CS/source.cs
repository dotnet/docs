using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 public void CreateOleDbCommand() 
 {
    string queryString = "SELECT * FROM Categories ORDER BY CategoryID";
    OleDbCommand command = new OleDbCommand(queryString);
    command.Connection = new OleDbConnection
       ("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=NWIND_RW.MDB");
    command.CommandTimeout = 20;
 }
// </Snippet1>

}
