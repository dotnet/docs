
class HttpWebRequest_Connection
{
  static void Main()
  {    
    try  
    {

      // Create a new HttpWebRequest object.Make sure that 
      // a default proxy is set if you are behind a firewall.
      HttpWebRequest myHttpWebRequest1 =
        (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
     
      myHttpWebRequest1.KeepAlive=false;
      // Assign the response object of HttpWebRequest to a HttpWebResponse variable.
      HttpWebResponse myHttpWebResponse1 = 
        (HttpWebResponse)myHttpWebRequest1.GetResponse();

      Console.WriteLine("\nThe HTTP request Headers for the first request are: \n{0}",myHttpWebRequest1.Headers);
      Console.WriteLine("Press Enter Key to Continue..........");
      Console.Read();

      Stream streamResponse=myHttpWebResponse1.GetResponseStream();
      StreamReader streamRead = new StreamReader( streamResponse );
      Char[] readBuff = new Char[256];
      int count = streamRead.Read( readBuff, 0, 256 );
      Console.WriteLine("The contents of the Html page are.......\n");  
      while (count > 0) 
      {
        String outputData = new String(readBuff, 0, count);
        Console.Write(outputData);
        count = streamRead.Read(readBuff, 0, 256);
      }
      Console.WriteLine();
      // Close the Stream object.
      streamResponse.Close();
      streamRead.Close();
      // Release the resources held by response object.
      myHttpWebResponse1.Close();
      // Create a new HttpWebRequest object for the specified Uri.
      HttpWebRequest myHttpWebRequest2 = 
        (HttpWebRequest)WebRequest.Create("http://www.contoso.com");
      myHttpWebRequest2.Connection="Close";
      // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
      HttpWebResponse myHttpWebResponse2 = 
        (HttpWebResponse)myHttpWebRequest2.GetResponse();
      // Release the resources held by response object.
      myHttpWebResponse2.Close();
      Console.WriteLine("\nThe Http RequestHeaders are \n{0}",myHttpWebRequest2.Headers);
      Console.WriteLine("\nPress 'Enter' Key to Continue.........");
      Console.Read();      
    }
    catch(ArgumentException e)
    {
      Console.WriteLine("\nThe second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close'");
      Console.WriteLine("\n{0}",e.Message);
    }
    catch(WebException e)
    {
      Console.WriteLine("WebException raised!");
      Console.WriteLine("\n{0}",e.Message);
      Console.WriteLine("\n{0}",e.Status);
    } 
    catch(Exception e)
    {
      Console.WriteLine("Exception raised!");
      Console.WriteLine("Source :{0} " , e.Source);
      Console.WriteLine("Message :{0} " , e.Message);
    }
  }
}
