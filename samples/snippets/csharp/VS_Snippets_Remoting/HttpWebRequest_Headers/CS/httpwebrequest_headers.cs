/*System.Net.HttpWebRequest.Headers
 This program demonstrates the 'Headers' property of 'HttpWebRequest' Class.
 A new 'HttpWebRequest' object is created.
 The (name,value) collection of the Http Headers are displayed to the console.
 The contents of the HTML page of the requested URI are displayed to the console. 
 
*/

using System;
using System.IO;
using System.Net;
using System.Text;
	
class HttpWebRequest_Headers
{
	public static void Main()
	{		
		try	
		{
// <Snippet1>
			// Create a new 'HttpWebRequest' Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");
			// Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();
			Console.WriteLine("\nThe HttpHeaders are \n\n\tName\t\tValue\n{0}",myHttpWebRequest.Headers);
			// Print the HTML contents of the page to the console. 
			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe HTML contents of page the are  : \n\n ");	
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
// </Snippet1>
			Console.WriteLine("\nPress 'Enter' Key to Continue.........");
			Console.Read();

		}
		catch(WebException e)
		{
			Console.WriteLine("\nWebException Caught!");
			Console.WriteLine("Message :{0}",e.Message);
			Console.WriteLine("Status  :{0}",e.Status);
		} 
		catch(Exception e)
		{
			Console.WriteLine("\nException Caught!");
			Console.WriteLine("Source  :{0}" , e.Source);
			Console.WriteLine("Message :{0}" , e.Message);
		}
	}
}


