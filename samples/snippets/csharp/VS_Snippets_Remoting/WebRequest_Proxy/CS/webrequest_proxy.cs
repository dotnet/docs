/*System.Net.WebRequest.Proxy
 This program demonstrates the 'Proxy' property of the 'WebRequest' class.
A WebRequest object is created and a new Proxy Object is created.
The Proxy Object is assigned the 'Proxy' Property of the WebRequest Object and then printed to the console,this is the default Proxy setting.
New Proxy address and the credentials are requested from the User.
A new Proxy object is then constructed from the inputs.
Then the 'Proxy' property of the request is associated with the new Proxy object constructed*/

using System;
using System.IO;
using System.Net;
using System.Text;

class WebRequest_Proxy
{
	static void Main()
	{
		try
		{
// <Snippet1>
			// Create a new request to the mentioned URL.				
			WebRequest myWebRequest=WebRequest.Create("http://www.contoso.com");

			WebProxy myProxy=new WebProxy();
			// Obtain the Proxy Prperty of the  Default browser.  
			myProxy=(WebProxy)myWebRequest.Proxy;

			// Print myProxy address to the console.
			Console.WriteLine("\nThe actual default Proxy settings are {0}",myProxy.Address);
         try
			{
				Console.WriteLine("\nPlease enter the new Proxy Address to be set ");
				Console.WriteLine("The format of the address should be http://proxyUriAddress:portaddress");
				Console.WriteLine("Example:http://proxyadress.com:8080");
				string proxyAddress;
				proxyAddress =Console.ReadLine();

				if(proxyAddress.Length==0)
				{
					myWebRequest.Proxy=myProxy;
				}
				else
				{
					Console.WriteLine("\nPlease enter the Credentials");
					Console.WriteLine("Username:");
					string username;
					username =Console.ReadLine();
					Console.WriteLine("\nPassword:");
					string password;
					password =Console.ReadLine();

					// Create a new Uri object.
					Uri newUri=new Uri(proxyAddress);

					// Associate the new Uri object to the myProxy object.
					myProxy.Address=newUri;

					// Create a NetworkCredential object and is assign to the Credentials property of the Proxy object.
					myProxy.Credentials=new NetworkCredential(username,password);
					myWebRequest.Proxy=myProxy;
				}
				Console.WriteLine("\nThe Address of the  new Proxy settings are {0}",myProxy.Address);
				WebResponse myWebResponse=myWebRequest.GetResponse();

				// Print the  HTML contents of the page to the console.
				Stream streamResponse=myWebResponse.GetResponseStream();
				StreamReader streamRead = new StreamReader( streamResponse );
				Char[] readBuff = new Char[256];
				int count = streamRead.Read( readBuff, 0, 256 );
				Console.WriteLine("\nThe contents of the Html pages are :");	
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
				Console.WriteLine("\nUriFormatException is thrown.Message is {0}",e.Message);
				Console.WriteLine("\nThe format of the myProxy address you entered is invalid");
				Console.WriteLine("\nPress any key to continue.........");
				Console.Read();
			}
// </Snippet1>

		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException is raised. ");
			Console.WriteLine("\nMessage:{0} ",e.Message);
			Console.WriteLine("\nStatus:{0}",e.Status);
		}
		catch(Exception e)
		{
			Console.WriteLine("\nException is raised. ");
			Console.WriteLine("\nMessage:{0} ",e.Message);
		}
	}
}

