// System.Net.WebClient.DownloadFile

/*
This program demonstrates the 'DownloadFile' method of 'WebClient' class.
It creates a URI to access a web resource at 'http://www.microsoft.com'. The Uri can point 
to any text or binary web resource, like images etc. The 'DownloadFile' method then downloads 
the target web resource which is a combination of the Uri and the actual web resource required,
into the current filesystem folder with a specified name.
Information regarding the sucess or failure of this operation is displayed on the console.
*/

using System;
using System.Net;
using System.Windows.Forms;

public class WebClient_DownloadFile 
{
	public static void Main() 
	{	
		try 
		{
// <Snippet1>
			string remoteUri = "http://www.contoso.com/library/homepage/images/";
			string fileName = "ms-banner.gif", myStringWebResource = null;
			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			// Concatenate the domain with the Web resource filename.
			myStringWebResource = remoteUri + fileName;
			Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
			// Download the Web resource and save it into the current filesystem folder.
			myWebClient.DownloadFile(myStringWebResource,fileName);		
			Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
			Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
// </Snippet1>
		} 
		catch (WebException e) 
		{
			// Display the exception.
			Console.WriteLine ("Download failed!!! WebException : "+ e.Message );
		} 
		catch (Exception e) 
		{
			// Display the exception.
			Console.WriteLine ("The following general exception was raised: "+ e.Message );
		}
	}
}
