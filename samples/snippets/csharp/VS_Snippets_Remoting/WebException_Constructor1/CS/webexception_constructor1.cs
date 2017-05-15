// System.Net.WebException.WebException();

/*
This program demonstrates the 'WebException()' constructor of 'WebException' class.
It creates a 'HttpConnect' object and calls the 'ConnectHttpServer' method with an invalid 'URL'.
When the method tries to establish a socket connection to that address an exception is thrown.In 
the 'catch' block  a new 'WebException' object is created  and  thrown to the caller.That exception 
is caught in the calling method and the error message is dispalyed to the console.
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
   		   Console.WriteLine("The Exception is :"+e.Message);
		      Console.WriteLine("The Exception is : Unable to Contact the server");
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
		      
		      IPHostEntry hostEntry = Dns.Resolve("http://www.contoso.com");

		      IPAddress serverAddress = hostEntry.AddressList[0];
		      IPEndPoint endPoint = new IPEndPoint(serverAddress, 80);
		      httpSocket.Connect(endPoint);
		      Console.WriteLine("Connection created successfully");
		      httpSocket.Close();
		   }
         catch(SocketException e)
		   {
   		   String exp = e.Message;	
	   	   // Throw the WebException with no parameters.
		      throw new WebException();
		   }
// </Snippet1>

	  }
}