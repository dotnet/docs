using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;

public class Sample
{


// <Snippet1>
 public void ShowOracleException() 
 {
    OracleConnection myConnection =
       new OracleConnection("Data Source=Oracle8i;Integrated Security=yes");

    try 
    {
       myConnection.Open();
    }
    catch (OracleException e) 
    {
      string errorMessage = "Code: " + e.Code + "\n" +
                            "Message: " + e.Message;

      System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
      log.Source = "My Application";
      log.WriteEntry(errorMessage);
      Console.WriteLine("An exception occurred. Please contact your system administrator.");
    }
 }
// </Snippet1>

}
