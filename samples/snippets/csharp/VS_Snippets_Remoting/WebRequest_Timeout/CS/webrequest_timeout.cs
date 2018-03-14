/*System.Net.WebRequest.Timeout
 * This program demonstrates the 'Timeout' property of the WebRequest Class.
  A new 'WebRequest' object is created .The default value of the 'Timeout' property is printed to the console.
  It is then set to a value and  displayed to the console. If the 'Timeout' property is set to a value less than 
  the time required to get the response an Exception is raised.'Timeout' property measures the time in 
  Milliseconds.*/
using System;
using System.IO;
using System.Net;
using System.Text;

class WebRequest_Timeout
{
	static void Main()
	{
	try	
		{
// <Snippet1>

                     // Create a new WebRequest Object to the mentioned URL.
			WebRequest myWebRequest=WebRequest.Create("http://www.contoso.com");
			Console.WriteLine("\nThe Timeout time of the request before setting is : {0} milliseconds",myWebRequest.Timeout);

			// Set the 'Timeout' property in Milliseconds.
			myWebRequest.Timeout=10000;

			// This request will throw a WebException if it reaches the timeout limit before it is able to fetch the resource.
                     WebResponse myWebResponse=myWebRequest.GetResponse();
			
// </Snippet1>
			// Print the Timeout time to the console.
			Console.WriteLine("\nThe Timeout time of the request after setting the time is : {0} milliseconds",myWebRequest.Timeout);
			Console.WriteLine("\nPress any Key to Continue...........");
			Console.Read();
			// Print the HTML contents of the page to the console. 
			Stream streamResponse=myWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of the Html page of the requested Url are  :");	
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
			Console.WriteLine("\nPress any Key to Continue...........");
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException is raised ");
			Console.WriteLine("\nMessage:{0} ",e.Message);
			Console.WriteLine("\nStatus:{0}",e.Status);
		}
		catch(Exception e)
		{
			Console.WriteLine("\nException is raised ");
			Console.WriteLine("\nMessage:{0} ",e.Message);
		}
	}
}
