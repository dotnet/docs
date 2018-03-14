/*Sytem.Net.HttpWebRequest.PipeLined
 This program demonstrates  'Pipelined' property of the 'HttpWebRequest' class.
  A new 'HttpWebRequest' object is created.The 'Pipelined' property is displayed to the console.
  HTTP Request  and  Response Headers are displayed to the console.The contents of the page of the
  requested URI are displayed to the console.

Note:The 'Pipelined' property is supported only by servers that allow Pipelining of requests.
*/

using System;
using System.IO;
using System.Net;
using System.Text;

class HttpWebRequest_Pipelined
{
	static void Main(string[] args)
	{
		try	
		{ 
			if(args.Length<1)
			{
				Console.WriteLine("\nPlease enter the Uri address as a command line parameter:");
				Console.WriteLine("[ Usage:HttpWebRequest_Pipelined http://www.microsoft.com ]");
			}
			else
			{
				GetPage(args[0]);	
			}
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Message :{0}",e.Message);			
		} 
		catch(Exception e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message :{0}" , e.Message);
		}
	}
	public static void GetPage(String myUri)
	{
		try
		{
// <Snippet1>
			// Create a 'HttpWebRequest' object.
			HttpWebRequest	myHttpWebRequest=(HttpWebRequest)WebRequest.Create(myUri);
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			// Display the contents of the page to the console.
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuffer = new Char[256];
			int count = streamRead.Read( readBuffer, 0, 256 );
			Console.WriteLine("\nThe contents of HTML page are.......");	
			while (count > 0) 
			{
				String outputData = new String(readBuffer, 0, count);
				Console.Write(outputData);
				count = streamRead.Read(readBuffer, 0, 256);
			}
			Console.WriteLine("\nHTTP Request  Headers :\n\n{0}",myHttpWebRequest.Headers);
			Console.WriteLine("\nHTTP Response Headers :\n\n{0}",myHttpWebResponse.Headers);
			streamRead.Close();
			streamResponse.Close();
			// Release the response object resources.
			myHttpWebResponse.Close();
			Console.WriteLine("\n'Pipelined' property is:{0}",myHttpWebRequest.Pipelined);	
			Console.WriteLine("\nPress 'Enter' Key to Continue......");
			Console.Read();	
// </Snippet1>
	
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Message : {0}",e.Message);			
		} 
		catch(Exception e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Message :{0} " , e.Message);
		}
	}
}
	
