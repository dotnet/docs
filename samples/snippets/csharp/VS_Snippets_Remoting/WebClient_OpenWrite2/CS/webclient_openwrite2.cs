// System.Net.WebClient.OpenWrite(String)
/*
This program demonstrates the 'OpenWrite(String)' method of "WebClient" class.
It accepts an Uri and some string content to be posted to the Uri. The
program makes a call to 'OpenWrite(String)' method and obtains a "Stream" instance
This stream is used to post data to the site. 

Note : Behaviour of this program may not be the same with all other sites. Also certain 
sites would not accept "Post" method thereby leading to an error.It is advisable 
to construct a site using files accompanying this and provide
url name of this site to the program.
*/
using System;
using System.Net;
using System.IO;
using System.Text;

public class WebClient_OpenWrite2
{
	public static void Main() 
	{	
		try 
		{
// <Snippet1>
			string uriString;
			Console.Write("\nPlease enter the URI to post data to : ");
			uriString = Console.ReadLine();
			Console.WriteLine("\nPlease enter the data to be posted to the URI {0}:",uriString);
			string postData = Console.ReadLine();
			// Apply Ascii Encoding to obtain an array of bytes. 
			byte[] postArray = Encoding.ASCII.GetBytes(postData);

			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();

			// postStream implicitly sets HTTP POST as the request method.
			Console.WriteLine("Uploading to {0} ...",  uriString);							Stream postStream = myWebClient.OpenWrite(uriString);

			postStream.Write(postArray,0,postArray.Length);

			// Close the stream and release resources.
			postStream.Close();

			Console.WriteLine("\nSuccessfully posted the data.");
// </Snippet1>
		} 
		catch (WebException e) 
		{
			Console.WriteLine ("The following exception was raised: "+ e.Message );
		}
		catch(Exception e)
		{
			Console.WriteLine ("The following exception was raised: "+ e.Message );
		}
	}
}

