// System.Net.NetworkCredential.Username;System.Net.NetworkCredential.Domain;System.Net.NetworkCredential.Password

/*This program demontrates the 'UserName','Domain' and 'Password' properties of 'NetworkCredential' class.
  It takes an URL, username, password and domainname from console. An empty 'NetworkCredential' object 
  is created.The 'UserName' ,'Password' and 'Domain' porperties of 'NetworkCredential' class are initialised 
  with the respective values taken from console. Then a 'WebRequest' object is created and the 'NetworkCredential'
  object is associated with it.A message is displayed onto the console on successful reception of response 
  otherwise an exception is thrown.
 */

using System;
using System.Net;
class CredentialCacheSnippet 
{
     public static void Main(string[] args) 
     {
        if (args.Length < 4) 
        {
          Console.WriteLine("\nPlease enter a protected resource Url and other details as command line parameter as below:");
          Console.WriteLine("\nUsage: NetworkCredential_UserName_Password_Domain URLname username password domainname");
          Console.WriteLine("\nExample: NetworkCredential_UserName_Password_Domain http://www.microsoft.com/net/ george george123 microsoft");
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
// <Snippet2>
// <Snippet3>
    // Create an empty instance of the NetworkCredential class.
    NetworkCredential myCredentials = new NetworkCredential("","","");
    myCredentials.Domain = domain;
    myCredentials.UserName = username;
    myCredentials.Password = passwd;

    // Create a WebRequest with the specified URL. 
    WebRequest myWebRequest = WebRequest.Create(url); 
    myWebRequest.Credentials = myCredentials;
    Console.WriteLine("\n\nUser Credentials:- Domain : {0} , UserName : {1} , Password : {2}",myCredentials.Domain,myCredentials.UserName,myCredentials.Password);
    
    // Send the request and wait for a response.
    Console.WriteLine("\n\nRequest to Url is sent.Waiting for response...Please wait ...");
    WebResponse myWebResponse = myWebRequest.GetResponse();
    
    // Process the response.
    Console.WriteLine("\nResponse received sucessfully");
    
    // Release the resources of the response object.
    myWebResponse.Close();

// </Snippet3>
// </Snippet2>
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
