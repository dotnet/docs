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
			Console.WriteLine("HttpWebResponse_ContentLength_ContentType http://www.microsoft.com/net/");
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
// <Snippet1>
	try 
 		  {	
			HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 

			Console.WriteLine("The encoding method used is: " + myHttpWebResponse.ContentEncoding);
			Console.WriteLine("The character set used is :" + myHttpWebResponse.CharacterSet);

			char seperator = '/';
			String contenttype = myHttpWebResponse.ContentType;
			// Retrieve 'text' if the content type is of 'text/html.
			String maintype = contenttype.Substring(0,contenttype.IndexOf(seperator));
			// Display only 'text' type.
			if (String.Compare(maintype,"text") == 0) 
				{
				Console.WriteLine("\n Content type is 'text'.");

// </Snippet1>
// <Snippet2>
				Stream receiveStream = myHttpWebResponse.GetResponseStream();
        		Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
        		StreamReader readStream = new StreamReader( receiveStream, encode );
				
        		Console.WriteLine("\r\nResponse stream received.");
				char[] read = new char[256];
        			
				int count = readStream.Read( read, 0, 256 );
        			Console.WriteLine("\nText retrieved from the URL follows:\r\n");

				int index = 0;
				while (index < myHttpWebResponse.ContentLength)
				{
    				// Dump the 256 characters on a string and display the string onto the console.
					String str = new String(read, 0, count);
					Console.WriteLine(str);
					index += count;
					count = readStream.Read(read, 0, 256);
				}
				// Release the resources of the stream object.
				receiveStream.Close();
				Console.WriteLine("");
				}
				// Release the resources of response object.
  				myHttpWebResponse.Close();
				
// </Snippet2>
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
