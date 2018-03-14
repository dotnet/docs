/*  System.Net.WebRequest.ContentType System.Net.WebRequest.ContentLength System.Net.WebRequest.GetRequestStream
  This program demonstrates 'GetRequestStream' method , 'ContentLength' and 'ContentType' properties of 
	'WebRequestClass'.
  A new 'WebRequest' object is created and the method used for sending data is set to 'POST' method by setting 
  The 'Method' property to 'POST'.The 'ContentType' property is set to 'application/x-www-form-urlencoded'.
  The 'ContentLength' property is set to the length of the Byte stream to be posted. A new 'Stream' object is
  obtained from the 'GetRequestStream' method of the 'WebRequest' class.Data to be posted is requested from 
  the user and is posted using the stream object.The HTML contents of the page are then displayed to the 
  console after the Posted data is accepted by the URL.

  Note: This program POSTs data to the Uri: http://www20.Brinkster.com/codesnippets/next.asp 
 */


 
using System;
using System.IO;
using System.Net;
using System.Text;

class WebRequest_ContentLength
{
	static void Main()
	{
		try	
		{
// <Snippet1>
// <Snippet2>
// <Snippet3>

                     // Create a new request to the mentioned URL. 				
			WebRequest myWebRequest=WebRequest.Create("http://www.contoso.com ");

			// Set the 'Method' property of the myWebrequest to POST.	
			myWebRequest.Method="POST";

			// Create a new string object to POST data to the above url.
			Console.WriteLine("\nThe value of 'ContentLength' property before sending the data is {0}",myWebRequest.ContentLength);
			Console.WriteLine("\nPlease enter the data to be posted to (http://www.contoso.com/codesnippets/next.asp) Uri");

			string inputData=Console.ReadLine();
			string postData="firstone="+inputData;
			ASCIIEncoding encoding=new ASCIIEncoding();
			byte[] byteArray=encoding.GetBytes(postData);

//<Snippet4>

			// Set the 'ContentType' property of the WebRequest.
			myWebRequest.ContentType="application/x-www-form-urlencoded";

			// Set the 'ContentLength' property of the WebRequest.
			myWebRequest.ContentLength=byteArray.Length;
			Stream newStream=myWebRequest.GetRequestStream();
			newStream.Write(byteArray,0,byteArray.Length);

			// Close the Stream object.
			newStream.Close();

			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse=myWebRequest.GetResponse();
			
//</Snippet4>

// </Snippet3>
// </Snippet2>			
// </Snippet1>
			Console.WriteLine("\nThe value of ContentLength property after sending the data is {0}",myWebRequest.ContentLength);
			Console.WriteLine("\nThe string entered has been succesfully posted to the Uri.");
			Console.WriteLine("\nPlease wait for the response.......");
			Stream streamResponse=myWebResponse.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			Char[] readBuff = new Char[256];
			int count = streamRead.Read( readBuff, 0, 256 );
			Console.WriteLine("\nThe contents of the Html page are :  \n");	
			while (count > 0) 
			{
				String outputData = new String(readBuff, 0, count);
				Console.WriteLine(outputData);
				count = streamRead.Read(readBuff, 0, 256);
			}
			// Close the Stream objects.
			streamRead.Close();
			streamResponse.Close();
			// Release the resources of response object.
			myWebResponse.Close();
			Console.WriteLine("\nPress 'Enter' Key to Continue.........");
			Console.Read();
		}
		catch(WebException e)
		{
			Console.WriteLine("WebException raised!");
			Console.WriteLine("\n{0}",e.Message);
			Console.WriteLine("\n{0}",e.Status);
		}
		catch(Exception e)
		{
			Console.WriteLine("Exception raised!");
        		Console.WriteLine("Source : " + e.Source);
			Console.WriteLine("Message : " + e.Message);
		}
	}
		
}

