// System.Net.HttpWebResponse.GetResponseStream

/* This program demonstrates the 'GetResponseStream' method of the 'HttpWebResponse' class.
It creates a web request and queries for a response.It then gets the response stream . 
This response stream is piped to a higher level stream reader. The reader reads 256 characters at a time ,
 writes them into a string and then displays the string in the console*/

using System;
using System.Net;
using System.IO;
using System.Text;

class HttpWebResponseSnippet 
{
    public static void Main(string[] args) 
	{
		if (args.Length < 1) 
		{	
			Console.WriteLine("\nPlease enter the url as command line parameter:");
			Console.WriteLine("Example:");
			Console.WriteLine("HttpWebResponse_GetResponseStream http://www.microsoft.com/net/");
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
            // Creates an HttpWebRequest with the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				// Sends the HttpWebRequest and waits for the response.			
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				// Gets the stream associated with the response.
				Stream receiveStream = myHttpWebResponse.GetResponseStream();
				Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
				// Pipes the stream to a higher level stream reader with the required encoding format. 
				StreamReader readStream = new StreamReader( receiveStream, encode );
            Console.WriteLine("\r\nResponse stream received.");
				Char[] read = new Char[256];
        		// Reads 256 characters at a time.    
				int count = readStream.Read( read, 0, 256 );
				Console.WriteLine("HTML...\r\n");
				while (count > 0) 
					{
    					// Dumps the 256 characters on a string and displays the string to the console.
						String str = new String(read, 0, count);
						Console.Write(str);
						count = readStream.Read(read, 0, 256);
					}
				Console.WriteLine("");
				// Releases the resources of the response.
				myHttpWebResponse.Close();
				// Releases the resources of the Stream.
				readStream.Close();
// </Snippet1>			
			} 
		catch(WebException e) 
		   {
				Console.WriteLine("\r\nWebException Raised. The following error occured : {0}",e.Status); 
		   }
		catch(Exception e)
			{
				Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
			}
	}
      
}