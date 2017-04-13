// System.Net.NetworkCredential.NetworkCredential(string,string)

/*This program demontrates the 'NetworkCredential(string,string)' constructor of 'NetworkCredential' class.
  It takes an URL, username, password and domainname from console and forms a 'NetworkCredential' object with 
  these arguments.Then a 'WebRequest' object is created and the 'NetworkCredential' object is associated with 
  it.A message is displayed onto the console on successful reception of response otherwise an exception is thrown.
 */

using System;
using System.Net;

class NetworkCredentialSnippet {
     public static void Main(string[] args) 
     {
        if (args.Length < 4) 
        {
          Console.WriteLine("\nPlease enter a protected resource Url and other details as command line parameter as below:");
          Console.WriteLine("\nUsage: NetworkCredential_Constructor2 URLname username password domainname");
          Console.WriteLine("\nExample: NetworkCredential_Constructor2 http://www.microsoft.com/net/ george george123 microsoft");
        } 
        else 
        {
            GetPage(args[0],args[1],args[2],args[3]);
        }
        Console.WriteLine("\n\nPress 'Enter key' to continue...");Console.ReadLine();
        return;
    }

  public static void GetPage(string url,string username,string passwd,string domain) 
   {
    try 
    {
// <Snippet1>
       // Call the onstructor  to create an instance of NetworkCredential with the 
       // specified user name and password.
       NetworkCredential myCredentials = new NetworkCredential(username,passwd);
  
      // Create a WebRequest with the specified URL. 
      WebRequest myWebRequest = WebRequest.Create(url);
      myCredentials.Domain = domain;
      myWebRequest.Credentials = myCredentials;
      Console.WriteLine("\n\nCredentials Domain : {0} , UserName : {1} , Password : {2}",
      myCredentials.Domain, myCredentials.UserName, myCredentials.Password);
      Console.WriteLine("\n\nRequest to Url is sent.Waiting for response...");
      
      
      // Send the request and wait for a response.
      WebResponse myWebResponse = myWebRequest.GetResponse(); 
      
      // Process the response.
      Console.WriteLine("\nResponse received successfully.");
      // Release the resources of the response object.
      myWebResponse.Close();
// </Snippet1>
      } 
      catch(WebException e) 
      {
        Console.WriteLine("\r\nWebException is raised.The Reason for failure is : {0}",e.Status); 
      }
    catch(Exception e)
    {
      Console.WriteLine("\nThe following exception was raised : {0}",e.Message);
    }
  }
}
