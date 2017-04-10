// System.Net.WebException.WebException(String,InnerException,Status,WebResponse);
/*
This program demonstrates the 'WebException(String,InnerException,Status,WebResponse)'  constructor of
'WebException' class.
A 'HttpConnect' class is defined which extends the 'WebResponse' class.  Then a 'HttpConnect' object is 
created by taking an uri(intranet) from the user as input and 'ConnectHttpServer' method is called to connect
the InternetServer at the specified 'URL'. It asks for a file named 'nhjj.htm' ,gets the response from the 
InternetServer and checks the status of the response. If status is '404 File not Found' a 'WebResponse' object
is created and then a new 'WebException' object is created and thrown.That exception is caught in the calling
method and the error message along with the response obtained from the InternetServer is displayed to the 
console.
*/


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

public class HttpConnect : WebResponse{

  public Stream getStream = null;

		static void Main()
		{
			 try
			 {
				Console.WriteLine("Please give any Intranet Site Address (eg:manjeera.wipro.com)");
				String uriConnect = Console.ReadLine();
				 HttpConnect myHttpConnect = new HttpConnect();
				 myHttpConnect.ConnectHttpServer(uriConnect);
			 }
			 catch(WebException e)
			 {
				Console.WriteLine("\nThe  WebException is :"+e.Message);
				Console.WriteLine("\nThe status of the WebException is :"+e.Status);
				Console.WriteLine("\nThe Inner Exception is :'"+e.InnerException+"'");
				Console.WriteLine("\nThe Web Response is:\n");
				StreamReader readStream = new StreamReader(e.Response.GetResponseStream());
				Console.WriteLine(readStream.ReadToEnd());
			 }
			 catch(Exception e)
			 {
				 Console.WriteLine(e);
			 }
	  }

		// Default constructor.
		HttpConnect()
		{
		}

		// Constructor accepting stream as a parameter.
		HttpConnect(Stream getStream)
		{
		  this.getStream = getStream;
		}

		// Override 'GetResponseStream' method of the  'WebResponse' class.
		public override Stream GetResponseStream()
		{ 
		  return getStream;
		}


    	public void ConnectHttpServer(String connectUri)
        {
// <Snippet1>
			 // Send the data. 
			 Encoding ASCII = Encoding.ASCII;
			 string requestPage = "GET /nhjj.htm HTTP/1.1\r\nHost: " + connectUri + "\r\nConnection: Close\r\n\r\n";
			 Byte[] byteGet = ASCII.GetBytes(requestPage);
			 Byte[] recvBytes = new Byte[256];

			 // Create an 'IPEndPoint' object.
	    
			 IPHostEntry hostEntry = Dns.Resolve(connectUri);
			 IPAddress serverAddress = hostEntry.AddressList[0];
			 IPEndPoint endPoint = new IPEndPoint(serverAddress, 80);
	   
			 // Create a 'Socket' object  for sending data.
			 Socket connectSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp);
	    
			 // Connect to host using 'IPEndPoint' object.

			 connectSocket.Connect(endPoint);
	    
			 // Sent the 'requestPage' text to the host.
			 connectSocket.Send(byteGet, byteGet.Length, 0);
	    
			 // Receive the information sent by the server.
			 Int32 bytesReceived = connectSocket.Receive(recvBytes, recvBytes.Length, 0);
			 String headerString = ASCII.GetString(recvBytes, 0, bytesReceived);
			


			
			// Check whether 'status 404' is there or not in the information sent by server.
			if(headerString.IndexOf("404")!=-1)
			{	 
				bytesReceived = connectSocket.Receive(recvBytes, recvBytes.Length, 0);
				MemoryStream memoryStream = new MemoryStream(recvBytes);
				getStream = (Stream) memoryStream;
		
				// Create a 'WebResponse' object
				WebResponse myWebResponse = (WebResponse) new HttpConnect(getStream);
				Exception myException = new Exception("File Not found");

				// Throw the 'WebException' object with a message string, message status,InnerException and WebResponse
				throw new WebException("The Requested page is not found.",myException,WebExceptionStatus.ProtocolError,myWebResponse);
 

			}

			connectSocket.Close();	
// </Snippet1>	
	    }
}