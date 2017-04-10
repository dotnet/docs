// System.Net.FileWebRequest.BeginGetRequestStream;System.Net.FileWebRequest.EndGetRequestStream;
// Snippet1 and Snippet2 go together

/*
  This program demonstrates 'BeginGetRequestStream' and 'EndGetRequestStream' method of 'FileWebRequest' class
  The path of the file from where content is to be read  is obtained as a command line argument and a 'webRequest'
  object is created.Using the 'BeginGetRequestStream' method and 'EndGetRequestStream' of 'FileWebRequest' class 
  a stream object is obtained which is used to write into the file.
*/


using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;

// <Snippet1>
// <Snippet2>

	public class RequestDeclare
	{
		 public FileWebRequest myFileWebRequest;	
		 public String userinput;
       
 		public RequestDeclare()
		{
			myFileWebRequest = null;
		}
	}
	
	class FileWebRequest_reqbeginend
	{
		public static ManualResetEvent allDone = new ManualResetEvent(false);

		static void Main(string[] args)
		{
		  if (args.Length < 1)
		  {
   		    Console.WriteLine("\nPlease enter the file name as command line parameter:");
 		       Console.WriteLine("Usage:FileWebRequest_reqbeginend <systemname>/<sharedfoldername>/<filename>\nExample:FileWebRequest_reqbeginend shafeeque/shaf/hello.txt");
		    
		  }  
		  else
		  {

		    try
			 {

			      // Place a webrequest.
			      WebRequest myWebRequest= WebRequest.Create("file://"+args[0]);
   			
	    	      // Create an instance of the 'RequestDeclare' and associate the 'myWebRequest' to it.		
			      RequestDeclare requestDeclare = new RequestDeclare();
			      requestDeclare.myFileWebRequest = (FileWebRequest)myWebRequest;
			      // Set the 'Method' property of 'FileWebRequest' object to 'POST' method.
			      requestDeclare.myFileWebRequest.Method="POST";
			      Console.WriteLine("Enter the string you want to write into the file:");
			      requestDeclare.userinput = Console.ReadLine();

			      // Begin the Asynchronous request for getting file content using 'BeginGetRequestStream()' method .
			      IAsyncResult r=(IAsyncResult) requestDeclare.myFileWebRequest.BeginGetRequestStream(new AsyncCallback(ReadCallback),requestDeclare);			
			      allDone.WaitOne();

			      Console.Read();
		    }
		    catch(ProtocolViolationException e)
		    {
		          Console.WriteLine("ProtocolViolationException is :"+e.Message);
		    }
		    catch(InvalidOperationException e)
		    {
			   	Console.WriteLine("InvalidOperationException is :"+e.Message);
		    }
		    catch(UriFormatException e)
		    {
				Console.WriteLine("UriFormatExceptionException is :"+e.Message);
			 }
		 }
		}

		private static void ReadCallback(IAsyncResult ar)
		{	

	     try
   	  {

			  // State of the request is asynchronous.
			  RequestDeclare requestDeclare=(RequestDeclare) ar.AsyncState;
			  FileWebRequest myFileWebRequest=requestDeclare.myFileWebRequest;
			  String sendToFile = requestDeclare.userinput;

			  // End the Asynchronus request by calling the 'EndGetRequestStream()' method.
			  Stream readStream=myFileWebRequest.EndGetRequestStream(ar);
						
			  // Convert the string into byte array.
				
			  ASCIIEncoding encoder = new ASCIIEncoding();
			  byte[] byteArray = encoder.GetBytes(sendToFile);
			
			  // Write to the stream.
			  readStream.Write(byteArray,0,sendToFile.Length);
			  readStream.Close();
			  allDone.Set();
				
			  Console.WriteLine("\nThe String you entered was successfully written into the file.");
	   	  Console.WriteLine("\nPress Enter to continue.");	


         }
        catch(ApplicationException e)
		  {
			  Console.WriteLine("ApplicationException is :"+e.Message);
		  }				

		}
// </Snippet2>
// </Snippet1>
	}





