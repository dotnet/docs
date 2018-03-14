/*System.Net.HttpWebRequest.Proxy
This program demonstrates the 'Proxy' property of the 'HttpWebRequest' class.
A 'HttpWebRequest' object and a  'Proxy' object is created.The Proxy Object is then assigned to 
the 'Proxy' Property of the 'HttpWebRequest' object and  printed onto the console(this is the default
Proxy setting).New Proxy address and the credentials are requested from the User.A new Proxy object is 
then constructed from the supplied inputs.Then the 'Proxy' property of the request is associated with the new 
Proxy object.
Note:No credentials are required if the Proxy does not require any authentication.
*/


using System;
using System.IO;
using System.Net;
using System.Text;

class HttpWebRequest_Proxy
{
  static void Main()
  {
	  try
    {
// <Snippet1>
        // Create a new request to the mentioned URL.				
        HttpWebRequest myWebRequest=(HttpWebRequest)WebRequest.Create("http://www.microsoft.com");

        // Obtain the 'Proxy' of the  Default browser.  
        IWebProxy proxy = myWebRequest.Proxy;
        // Print the Proxy Url to the console.
        if (proxy != null)
        {
            Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri));
        } 
        else
        {
            Console.WriteLine("Proxy is null; no proxy will be used");
        }

        WebProxy myProxy=new WebProxy();

        Console.WriteLine("\nPlease enter the new Proxy Address that is to be set:");
        Console.WriteLine("(Example:http://myproxy.example.com:port)");
        string proxyAddress;

        try
        {
            proxyAddress =Console.ReadLine();
            if(proxyAddress.Length>0)
            {
                Console.WriteLine("\nPlease enter the Credentials (may not be needed)");
                Console.WriteLine("Username:");
                string username;
                username =Console.ReadLine();
                Console.WriteLine("\nPassword:");
                string password;
                password =Console.ReadLine();					
                // Create a new Uri object.
                Uri newUri=new Uri(proxyAddress);
                // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                myProxy.Address=newUri;
                // Create a NetworkCredential object and associate it with the 
                // Proxy property of request object.
                myProxy.Credentials=new NetworkCredential(username,password);
                myWebRequest.Proxy=myProxy;
            }
            Console.WriteLine("\nThe Address of the  new Proxy settings are {0}",myProxy.Address);
            HttpWebResponse myWebResponse=(HttpWebResponse)myWebRequest.GetResponse();
            // </Snippet1>

            // Print the HTML contents of the page to the console.
            Stream streamResponse=myWebResponse.GetResponseStream();
            StreamReader streamRead = new StreamReader( streamResponse );
            Char[] readBuff = new Char[256];
            int count = streamRead.Read( readBuff, 0, 256 );
            Console.WriteLine("\nThe contents of the HTML pages are :");	
            while (count > 0) 
            {
                String outputData = new String(readBuff, 0, count);
                Console.Write(outputData);
                count = streamRead.Read(readBuff, 0, 256);
            }
            // Close the Stream object.
            streamResponse.Close();			
            streamRead.Close();
            // Release the HttpWebResponse Resource.
            myWebResponse.Close();
            Console.WriteLine("\nPress any key to continue.........");
            Console.Read();	
        }
        catch(UriFormatException e)
        {
            Console.WriteLine("\nUriFormatException is thrown. Message: {0}",e.Message);
            Console.WriteLine("\nThe format of the Proxy address you entered is invalid");
            Console.WriteLine("\nPress any key to continue.........");
            Console.Read();
        }
    }
    catch(WebException e)
    {
        Console.WriteLine("\nWebException raised!");
        Console.WriteLine("\nMessage:{0} ",e.Message);
        Console.WriteLine("\nStatus:{0} ",e.Status);
    }
    catch(Exception e)
    {
        Console.WriteLine("\nException is raised. ");
        Console.WriteLine("\nMessage:{0} ",e.Message);
    }
  }
}

