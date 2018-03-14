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
 public void CreateMyOleDbCommand() 
 {
    OleDbCommand command = new OleDbCommand();
    command.CommandText = "SELECT * FROM Categories ORDER BY CategoryID";
    command.CommandTimeout = 20;
 }
// </Snippet1>

}
