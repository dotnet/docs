/* System.Net.HttpWebRequest.AllowAutoRedirect System.Net.HttpWebRequest.Address
 This program demonstrates  'AllowAutoRedirect' and 'Address' properties of 'HttpWebRequest' Class.
 A new 'HttpWebRequest' object is created. The 'AllowAutoredirect' property which redirects a page automatically 
 to the new Uri is set to true.Using the 'Address' property, the address of the 'Responding Uri' is printed to 
 console.The contents of the redirected page are displayed to the console.
*/

using System;
using System.IO;
using System.Net;
using System.Text;

class HttpWebRequest_AllowAutoRedirect
{
	static void Main()
	{
		try	
		{
 // <Snippet1>
 // <Snippet2>
			// Create a new HttpWebRequest Object to the mentioned URL.
			HttpWebRequest myHttpWebRequest=(HttpWebRequest)WebRequest.Create("http://www.contoso.com");	
			myHttpWebRequest.MaximumAutomaticRedirections=1;
			myHttpWebRequest.AllowAutoRedirect=true;
			HttpWebResponse myHttpWebResponse=(HttpWebResponse)myHttpWebRequest.GetResponse();	
 // </Snippet2>
    			Stream streamResponse=myHttpWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of Html Page are :  ");	
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
			Console.WriteLine("\nThe Requested Uri is {0}",myHttpWebRequest.RequestUri);
			Console.WriteLine("\nThe Actual Uri responding to the request is \n{0}",myHttpWebRequest.Address);
// </Snippet1>
			Console.WriteLine("\nPress any Key to Continue..........");
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("WebException raised!");
			Console.WriteLine("\nMessage:{0}",e.Message);
			Console.WriteLine("\nStatus:{0}",e.Status);
			
		} 
		catch(Exception e)
		{
			Console.WriteLine("Exception raised!");
			Console.WriteLine("\nSource : " + e.Source);
			Console.WriteLine("\nMessage : " + e.Message);
		}
	}
}

	

