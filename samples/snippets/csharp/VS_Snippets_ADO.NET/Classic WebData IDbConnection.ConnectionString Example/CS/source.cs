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
 public void CreateOleDbConnection(){
    OleDbConnection connection = new OleDbConnection();
    connection.ConnectionString = 
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Northwind.mdb";
    Console.WriteLine("Connection State: " + connection.State.ToString());
 }
// </Snippet1>

}
