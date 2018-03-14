using System;
using System.Xml;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 public void CreateOdbcConnection() 
 {
     string connectionString = "Driver={SQL Native Client};Server=(local);Trusted_Connection=Yes;Database=AdventureWorks;";

     using (OdbcConnection connection = new OdbcConnection(connectionString))
     {
         connection.Open();
         Console.WriteLine("ServerVersion: " + connection.ServerVersion
             + "\nDatabase: " + connection.Database);

         // The connection is automatically closed at 
         // the end of the Using block.
     }
 }
// </Snippet1>

}
