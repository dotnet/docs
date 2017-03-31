// System.Net.NetworkCredential.GetCredential
/*This program demontrates the 'GetCredential' of 'NetworkCredential' class.
  It accepts an URL, username and password from console. Creates a 'NetworkCredential' object 
  using these parameters. A 'WebRequest' object is created to access the Uri "http://www.microsoft.com"
  and the 'NetworkCredential' object is assigned as it's Credentials.
  A message is displayed onto the console on successful reception of response 
  otherwise an exception is thrown.
 */

using System;
using System.Net;
class NetworkCredential_GetCredential 
{
     public static void Main(string[] args) 
	 {
        if (args.Length < 3) {
			Console.WriteLine("\nPlease enter a protected resource Url and other details as command line parameter as below:");
			Console.WriteLine("\nUsage: NetworkCredential_GetCredential URLname username password");
			Console.WriteLine("\nExample: NetworkCredential_GetCredential http://www.microsoft.com/net/ george george123");
        } else {
            GetPage(args[0],args[1],args[2]);
        }
        Console.WriteLine("\n\nPress 'Enter' to continue...");Console.ReadLine();
        return;
    }

  public static void GetPage(string url,string userName,string password) 
   {
	  try 
		{
// <Snippet1>
      // Create an empty instance of the NetworkCredential class.
      NetworkCredential myCredentials = new NetworkCredential(userName,password);
      // Create a webrequest with the specified URL. 
      WebRequest myWebRequest = WebRequest.Create(url); 
      myWebRequest.Credentials = myCredentials.GetCredential(new Uri(url),"");
      Console.WriteLine("\n\nUser Credentials:- UserName : {0} , Password : {1}",myCredentials.UserName,myCredentials.Password);
      // Send the request and wait for a response.
      Console.WriteLine("\n\nRequest to Url is sent.Waiting for response...Please wait ...");
      WebResponse myWebResponse = myWebRequest.GetResponse();
      // Process the response.
         Console.WriteLine("\nResponse received sucessfully");
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
