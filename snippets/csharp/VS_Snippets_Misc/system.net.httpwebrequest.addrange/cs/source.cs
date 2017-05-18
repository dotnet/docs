/*System.Net.HttpWebRequest.AddRange(int,int)
This program demonstrates 'AddRange(int)' method of 'HttpWebRequest class.
A new 'HttpWebRequest' object is created.The number of characters of the response to be received can be 
restricted by the 'AddRange' method.By calling 'AddRange(50,150)' on the 'HttpWebRequest' object the content 
of the response page is restricted from the 50th character to 150th charater.The response of the request is
obtained and displayed to the console.
*/

using System;
using System.IO;
using System.Net;

class HttpWebRequest_AddRange_int
{
	static void Main()
	{
		try	
		{
// <Snippet1>
			// Create a New 'HttpWebRequest' object .
			HttpWebRequest myHttpWebRequest1=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest1.AddRange(1000);	
			Console.WriteLine("Call AddRange(1000)");
			Console.Write("Resulting Headers: ");
			Console.WriteLine(myHttpWebRequest1.Headers.ToString());
			
			// Create a New 'HttpWebRequest' object .
			HttpWebRequest myHttpWebRequest2=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest2.AddRange(-1000);	
			Console.WriteLine("Call AddRange(-1000)");
			Console.Write("Resulting Headers: ");
			Console.WriteLine(myHttpWebRequest2.Headers.ToString());
// </Snippet1>			
		}	
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");	
			Console.WriteLine("Message :{0} ",e.Message);
		}
		catch(Exception e)
		{
			Console.WriteLine("\nException Caught!");	
			Console.WriteLine("Message :{0} ",e.Message);
		}
	}
}

	

