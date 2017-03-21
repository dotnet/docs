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
      string errorMessage = "Message: " + e.Message + "\n" +
                            "Source: " + e.Source;

      System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
      log.Source = "My Application";
      log.WriteEntry(errorMessage);
      Console.WriteLine("An exception occurred. Please contact your system administrator.");
    }
 }