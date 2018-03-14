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
 public void ShowOdbcException() 
 {
    string mySelectQuery = "SELECT column1 FROM table1";
    OdbcConnection myConnection =
       new OdbcConnection("DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=northwind;");
    OdbcCommand myCommand = new OdbcCommand(mySelectQuery,myConnection);
    try 
    {
       myCommand.Connection.Open();
    }
    catch (OdbcException e) 
    {
      string errorMessages = "";

      for (int i=0; i < e.Errors.Count; i++)
      {
          errorMessages += "Index #" + i + "\n" +
                           "Message: " + e.Errors[i].Message + "\n" +
                           "NativeError: " + e.Errors[i].NativeError.ToString() + "\n" +
                           "Source: " + e.Errors[i].Source + "\n" +
                           "SQL: " + e.Errors[i].SQLState + "\n";
      }

      System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
      log.Source = "My Application";
      log.WriteEntry(errorMessages);
      Console.WriteLine("An exception occurred. Please contact your system administrator.");
    }
 }
// </Snippet1>

}
