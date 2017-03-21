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