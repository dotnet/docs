/*System.Net.HttpWebRequest.Timeout
  This program demonstrates 'Timeout' property of the HttpWebRequest Class.
  A new HttpWebRequest Object is created .The default value of the 'Timeout' property is printed to the console.
  It is then set to some value and displayed to the console. If the 'Timeout' property is set to a value less
  than the time required to get the response an 'Exception' is raised. 'Timeout' property measures the time in
  Milliseconds. 
  */
using System;
using System.IO;
using System.Net;
using System.Text;

class HttpWebRequest_Timeout
{
	static void Main()
	{
		try	
		{
// <Snippet1>
			// Create a new 'HttpWebRequest' Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			Console.WriteLine("\nThe timeout time of the request before setting the property is  {0}  milliSeconds.",myHttpWebRequest.Timeout);
			// Set the  'Timeout' property of the HttpWebRequest to 10 milliseconds.
			myHttpWebRequest.Timeout=10;
			// Display the 'Timeout' property of the 'HttpWebRequest' on the console.
			Console.WriteLine("\nThe timeout time of the request after setting the timeout is {0}  milliSeconds.",myHttpWebRequest.Timeout);
			// A HttpWebResponse object is created and is GetResponse Property of the HttpWebRequest associated with it 
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
// </Snippet1>
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of the HTML page are, ");	
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
			myHttpWebResponse.Close();
			Console.WriteLine("\nPress any Key to Continue.............");
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException raised!");
			Console.WriteLine("\nMessage:{0} ",e.Message);
			Console.WriteLine("\nStatus:{0} ",e.Status);
		}
		catch(Exception e)
		{
			Console.WriteLine("Exception raised!");
			Console.WriteLine("\nSource : " + e.Source);
			Console.WriteLine("\nMessage : " + e.Message);
		}
	}
}
	
	

