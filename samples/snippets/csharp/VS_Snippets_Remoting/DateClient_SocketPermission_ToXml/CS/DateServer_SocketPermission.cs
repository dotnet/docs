/*
  This program demonstrates the 'AcceptList' property  of 'SocketPermission' class.

  This program provides a class called 'DateServer' that functions as a server 
  for a 'DateClient'. A 'DateServer' is a server that provides the current date on
  the server in response to a request from a client. The 'DateServer' class 
  provides a method called 'Create' which waits for client connections and sends
  the current date on that socket connection. Within the 'Create' method of
  'DateServer' class an instance of 'SocketPermission' is created with the 
  'SocketPermission(NetworkAccess, TransportType, string, int)' constructor.
  If the calling method has the requisite permissions the 'Create' method waits 
  for client connections and sends the current date on the socket connection.

*/

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security;
using System.Collections;

public class DateServer {

	// Client connecting to the date server.
	private Socket clientSocket; 
	private Socket serverSocket;
	private Encoding asciiEncoding;

	public readonly int serverBacklog;

	public static void Main(String[] args) {
		if(args.Length != 1) 
		{
			PrintUsage();
			return;
		}
		DateServer server = new DateServer();
		try {
			server.Create(args[0]);
		}
		catch(SecurityException securityException) {
			Console.WriteLine("SecurityException caught !!!");
			Console.WriteLine("Message : " + securityException.Message);
		}
		catch(Exception exception) {
			Console.WriteLine("Exception caught !!!");
			Console.WriteLine("Message " + exception.Message);
		}
	}

	public DateServer() {
		asciiEncoding = Encoding.ASCII;
		serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		serverBacklog = 10;
	}

	// Return the current date on the client connection.
	public bool Create(String portString) {
		// Create another 'SocketPermission' object with two ip addresses.
		// First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and
      // for 'All' ports for the ip-address.
		SocketPermission socketPermission = 
						new SocketPermission(NetworkAccess.Accept,
											 TransportType.All,
											 "192.168.144.238",
											 SocketPermission.AllPorts);


        // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and 
        // for 'All' ports for the ip-address.
		socketPermission.AddPermission(NetworkAccess.Accept,
									   TransportType.All,
									   "192.168.144.239",
									   SocketPermission.AllPorts);

		Console.WriteLine("Display result of AcceptList property : ");
		IEnumerator enumerator = socketPermission.AcceptList;
		while(enumerator.MoveNext()) {
			Console.WriteLine("The hostname is       : {0}", ((EndpointPermission)enumerator.Current).Hostname);
			Console.WriteLine("The port is           : {0}", ((EndpointPermission)enumerator.Current).Port);
			Console.WriteLine("The Transport type is : {0}", ((EndpointPermission)enumerator.Current).Transport);
		}

		// Demand for the calling method for requisite socket permissions.
		socketPermission.Demand();
		serverSocket.Bind(new IPEndPoint((Dns.Resolve(Dns.GetHostName()).AddressList)[0], Int16.Parse(portString)));
		serverSocket.Listen(serverBacklog);
		while(true) {
			try {
				clientSocket = serverSocket.Accept();
				byte[] sendByte = asciiEncoding.GetBytes(DateTime.Now.ToString());
				clientSocket.Send(sendByte, sendByte.Length, 0);
				clientSocket.Close();
			}
			catch(Exception e) {
				Console.WriteLine("\nException raised : {0}", e.Message);
				return false;
			}
		}
	}

	public static void PrintUsage() {
		Console.WriteLine("Usage : DateServer_SocketPermission");
		Console.WriteLine("\tDateServer_SocketPermission <port>");
		Console.WriteLine("\tport is the port on which the DateServer is listening");
	}
};
