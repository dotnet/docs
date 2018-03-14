// System.Net.WebException.WebException(String);
/*
This program demonstrates the 'WebException(String)' constructor of 'WebException' class.
It creates a 'HttpConnect' object and calls the 'ConnectHttpServer' method with invalid 'URL'.
When the method tries to establish a socket connection to that address an exception is thrown.In 
the 'catch' block  a new 'WebException' object is created with a message(specific to the present 
situatuation) and  thrown to the caller.That exception is caught in the calling method and the 
error message is dispalyed on the console.
*/


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


public class HttpConnect{

		static void Main(String[] args)
		{
		   try
		   {
		      HttpConnect myHttpConnect = new HttpConnect();
			   // If the Uri is valid  then 'ConnectHttpServer' method will connect to the server.
			   myHttpConnect.ConnectHttpServer("www.contoso.com");
		   }
         catch(WebException e)
		   {
		      Console.WriteLine("\nThe New Message is:"+e.Message);
		   }
		}

    	public void ConnectHttpServer(String connectUri)
      {
// <Snippet1>
	      try
         {
		      // A 'Socket' object has been created.
		      Socket httpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		      // The IPaddress of the unknown uri is resolved using the 'Dns.Resolve' method. 
		      IPHostEntry hostEntry = Dns.Resolve(connectUri);

		      IPAddress serverAddress = hostEntry.AddressList[0];
		      IPEndPoint endPoint = new IPEndPoint(serverAddress, 80);
 		      httpSocket.Connect(endPoint);
		      Console.WriteLine("Connection created successfully");
		      httpSocket.Close();
		   }
         catch(SocketException e)
		   {		     
		      Console.WriteLine("\nException thrown.\nThe Original Message is: "+e.Message);
		      // Throw the 'WebException' object with a message string specific to the situation.
		      throw new WebException("Unable to locate the Server with 'www.contoso.com' Uri.");
		   }
// </Snippet1>
	   }

}