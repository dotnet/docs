/*System.Net.WebRequest.Create(Uri)

This program demonstrates the 'Create(Uri)' method of the 'WebRequest' class.
A new 'Uri' object is created to the specified Uri.
A new 'WebRequest' object is created to the 'specified' Uri by passing the 'Uri' object as parameter.
The response is obtained .
The HTML contents of the page of the requested Uri are displayed to the console.

*/

using System;
using System.Net;
using System.IO;
using System.Text;

class WebRequest_Create_Uri
{
	public static void Main()
	{
		try
		{
// <Snippet1>	
			// Create a new 'Uri' object with the specified string.
			Uri myUri =new Uri("http://www.contoso.com");
			// Create a new request to the above mentioned URL.	
			WebRequest myWebRequest= WebRequest.Create(myUri);
			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse= myWebRequest.GetResponse();
// </Snippet1>
			Stream streamResponse=myWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of HTML Page are :  \n");	
			while (count > 0) 
			{
				String outputData = new String(readBuff, 0, count);
				Console.Write(outputData);
				count = streamRead.Read(readBuff, 0, 256);
			}
			// Close the Stream object.
			streamResponse.Close();
			streamRead.Close();
			// Release the WebResponse Resource.
			myWebResponse.Close();
			Console.WriteLine("\nPress 'Enter' key to continue.................");	
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Source   :{0}",e.Source);
			Console.WriteLine("Message  :{0}",e.Message);			
		} 
		catch(Exception e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Source   :{0} ", e.Source);
			Console.WriteLine("Message  :{0} " , e.Message);
		}
	}
}
