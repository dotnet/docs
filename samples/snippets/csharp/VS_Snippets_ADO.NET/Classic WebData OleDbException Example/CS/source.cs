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
 public void ShowOleDbException() 
 {
    string mySelectQuery = "SELECT column1 FROM table1";
    OleDbConnection myConnection =
       new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;DataSource=");
    OleDbCommand myCommand = new OleDbCommand(mySelectQuery,myConnection);

    try 
    {
       myCommand.Connection.Open();
    }
    catch (OleDbException e) 
    {
      string errorMessages = "";

      for (int i=0; i < e.Errors.Count; i++)
      {
          errorMessages += "Index #" + i + "\n" +
                           "Message: " + e.Errors[i].Message + "\n" +
                           "NativeError: " + e.Errors[i].NativeError + "\n" +
                           "Source: " + e.Errors[i].Source + "\n" +
                           "SQLState: " + e.Errors[i].SQLState + "\n";
      }

      System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
      log.Source = "My Application";
      log.WriteEntry(errorMessages);
      Console.WriteLine("An exception occurred. Please contact your system administrator.");
    }
 }
// </Snippet1>

}
