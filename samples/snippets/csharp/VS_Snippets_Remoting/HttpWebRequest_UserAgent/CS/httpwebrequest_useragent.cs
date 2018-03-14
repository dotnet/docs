/*System.Net.HttpWebRequest.UserAgent
This program demonstrates 'UserAgent' property of 'HttpWebRequest' Class.
A new 'HttpWebRequest' object is created.The 'UserAgent' property is set to
"Mozilla/4.0 (compatible; MSIE 6.0b; Windows NT 5.0; COM+ 1.0.2702)".
This inturn sets the 'User-Agent' field of HTTP Request headers.
The response is obtained and displayed to the console.
*/

using System;
using System.IO;
using System.Net;

class HttpWebRequest_UserAgent
{
	static void Main()
	{
		try	
		{
// <Snippet1>
			// Create a new 'HttpWebRequest' object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			myHttpWebRequest.UserAgent=".NET Framework Test Client";
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			// Display the contents of the page to the console.
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of HTML Page are :\n");	
			while (count > 0) 
			{
				String outputData = new String(readBuff, 0, count);
				Console.Write(outputData);
				count = streamRead.Read(readBuff, 0, 256);
			}
			// Release the response object resources.
			streamRead.Close();
			streamResponse.Close();
			myHttpWebResponse.Close();
// </Snippet1>
			Console.WriteLine("\nHTTP Request Headers :\n{0}",myHttpWebRequest.Headers);
			Console.WriteLine("\nUserAgent is:{0}",myHttpWebRequest.UserAgent);
			Console.WriteLine("\nPress 'Enter' Key to Continue...........");
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Message :{0} ",e.Message);
			Console.WriteLine("Status  :{0} ",e.Status);
		}
		catch(Exception e)
		 {
			Console.WriteLine("\nException Caught!");
        		Console.WriteLine("Source  : " + e.Source);
			Console.WriteLine("Message : " + e.Message);
		}
	}
}

	

