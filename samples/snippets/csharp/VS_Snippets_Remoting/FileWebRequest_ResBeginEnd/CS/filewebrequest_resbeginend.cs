// System.Net.FileWebRequest.BeginGetResponse;System.Net.FileWebRequest.EndGetResponse;
// Snippet1 and Snippet2 go together
/* 
  This program demonstrates 'BeginGetResponse' and 'EndGetResponse' methods of 'FileWebRequest' class.
  The path of the file from where content is to be read  is obtained as a command line argument and a 
  'WebRequest' object is created. Using the 'BeginGetResponse' method and 'EndGetResponse' of 'FileWebRequest' 
  class a 'FileWebResponse' object is obtained which is used to print the content on the file.
*/


using System;
using System.Net;
using System.IO;
using System.Threading;

// <Snippet1>
// <Snippet2>

	public class RequestDeclare
	{
   	public FileWebRequest myFileWebRequest;	
       
 		public RequestDeclare()
		{
			myFileWebRequest = null;
		}
	}
	
	
	class FileWebRequest_resbeginend
	{

		public static ManualResetEvent allDone = new ManualResetEvent(false);

		static void Main(string[] args)
		{
			
		    if (args.Length < 1)
		    {
		       Console.WriteLine("\nPlease enter the file name as command line parameter:");
 		       Console.WriteLine("Usage:FileWebRequest_resbeginend <systemname>/<sharedfoldername>/<filename>\nExample:FileWebRequest_resbeginend shafeeque/shaf/hello.txt");
		    }  
		    else
		    {
		      try
            {


			      // Place a 'Webrequest'.
			      WebRequest myWebRequest= WebRequest.Create("file://"+args[0]);
			      // Create an instance of the 'RequestDeclare' and associating the 'myWebRequest' to it.		
			      RequestDeclare myRequestDeclare = new RequestDeclare();
			      myRequestDeclare.myFileWebRequest = (FileWebRequest)myWebRequest;
			  

			      // Begin the Asynchronous request for getting file content using 'BeginGetResponse()' method.	
			      IAsyncResult asyncResult =(IAsyncResult) myRequestDeclare.myFileWebRequest.BeginGetResponse(new AsyncCallback(RespCallback),myRequestDeclare);			
			      allDone.WaitOne();

	        
			   }
            catch(ArgumentNullException e)
			   {
			      Console.WriteLine("ArgumentNullException is :"+e.Message);
			   }
			   catch(UriFormatException e)
		      {
			      Console.WriteLine("UriFormatException is :"+e.Message);
		      }
		   }
		}

	  private static void RespCallback(IAsyncResult ar)
	  {	


			   // State of request is asynchronous.
				RequestDeclare requestDeclare=(RequestDeclare) ar.AsyncState;
					
				FileWebRequest  myFileWebRequest=requestDeclare.myFileWebRequest;
			
			   // End the Asynchronus request by calling the 'EndGetResponse()' method.
				
				FileWebResponse myFileWebResponse = (FileWebResponse) myFileWebRequest.EndGetResponse(ar);


			    // Reade the response into Stream.
				StreamReader streamReader= new StreamReader(myFileWebResponse.GetResponseStream());


				Char[] readBuffer = new Char[256];
					
				int count = streamReader.Read( readBuffer, 0, 256 );

				Console.WriteLine("The contents of the file are :\n");
		
				while (count > 0) 
				{
					String str = new String(readBuffer, 0, count);
					Console.WriteLine(str);
					count = streamReader.Read(readBuffer, 0, 256);
				}
				
				streamReader.Close();
				// Release the response object resources.
				myFileWebResponse.Close();
				allDone.Set();
				Console.WriteLine("File reading is over.");	
		}

	}
// </Snippet2>			
// </Snippet1>
