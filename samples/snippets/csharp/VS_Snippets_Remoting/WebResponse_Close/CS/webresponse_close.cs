// System.Net.WebResponse.Close

/*This program demonstrates the 'Close' method of 'WebResponse' Class. 
It takes an URL from console and creates a 'WebRequest' object for the Url.It then gets back 
the response object from the Url. The response object can be processed as desired.
The program then closes the response object and releases resources associated with it.*/

using System;
using System.Net;
using System.IO;
using System.Text;

class WebResponseSnippet {
    

    public static void Main(string[] args) 
    {
      if (args.Length < 1) 
		{
			Console.WriteLine("\nPlease type the Url as command line parameter");
			Console.WriteLine("Example:");
			Console.WriteLine("WebResponse_Close http://www.microsoft.com/net/");
      }
		else
		{
            GetPage(args[0]);
      }
      Console.WriteLine("Press any key to continue...");
		Console.ReadLine();
      return;
    }

  public static void GetPage(String url) 
   {
	   try 
         {
// <Snippet1>            
				// Create a 'WebRequest' object with the specified url. 	
				WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com"); 
				// Send the 'WebRequest' and wait for response.	
				WebResponse myWebResponse = myWebRequest.GetResponse(); 
				
				// Process the response here.
				Console.WriteLine("\nResponse Received.Trying to Close the response stream..");
				// Release resources of response object.
				myWebResponse.Close();
				Console.WriteLine("\nResponse Stream successfully closed");
// </Snippet1>			
        	} 
		catch(WebException e) 
			{
				Console.WriteLine("\r\nWebException Raised.Status is: {0}",e.Status); 
        	}
		catch(Exception e)
			{
				Console.WriteLine("\nThe following Exception was raised.Message is: {0}",e.Message);
			}
	}
}
