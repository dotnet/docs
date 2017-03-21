
  // Set the declarative security for the URI.
  [WebPermission(SecurityAction.Deny, Connect = @"http://www.contoso.com/")]
  public void Connect() 
  {
    // Throw an exception.   
    try
    {
      HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception : " + e.ToString());
    }