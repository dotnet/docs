/*
  This program demonstrates the 'ToXml' and 'IsUnrestricted' method and 'ConnectList' property of 
  'SocketPermission' class.
  
  This program provides a class called 'DateClient' that functions as a client
  for a 'DateServer'. A 'DateServer' is a server that provides the current date on
  the server in response to a request from a client. The 'DateClient' class 
  provides a method called 'GetDate' which returns the current date on the server.
  The 'GetDate' is the method that shows the use of 'SocketPermission' class. An
  instance of 'SocketPermission' is obtained using the 'FromXml' method. Another
  instance of 'SocketPermission' is created with the 'SocketPermission(NetworkAccess,
   TransportType, string, int)' constructor. A third 'SocketPermission' object is 
  formed from the union of the above two 'SocketPermission' objects with the use of the
  'Union' method of 'SocketPermission' class . This 'SocketPermission' object is used by
  the 'GetDate' method to verify the permissions of the calling method. If the calling 
  method has the requisite permissions the 'GetDate' method connects to the 'DateServer'
  and returns the current date that the 'DateServer' sends. If any exception occurs
  the 'GetDate' method returns an empty string.

  Note: This program requires 'DateServer_SocketPermission' program executing.
*/

// <Snippet1>
// <Snippet2>
// <Snippet3>
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections;
using System.Security;
using System.Security.Permissions;

public class DateClient {

	private Socket serverSocket;
	private Encoding asciiEncoding; 
	private IPAddress serverAddress;

	private int serverPort;

	// The constructor takes the address and port of the remote server.
	public DateClient(IPAddress serverIpAddress, int port) {
		serverAddress = serverIpAddress;
		serverPort = port;
		serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		asciiEncoding = Encoding.ASCII;
	}

	// Print a security element and all its children, in a depth-first manner.
	private void PrintSecurityElement(SecurityElement securityElementObj, int depth) {

		Console.WriteLine("Depth    : {0}", depth);
		Console.WriteLine("Tag      : {0}", securityElementObj.Tag);
		Console.WriteLine("Text     : {0}", securityElementObj.Text);
		if(securityElementObj.Children != null)
			Console.WriteLine("Children : {0}", securityElementObj.Children.Count);

		if(securityElementObj.Attributes != null) {
			IEnumerator attributeEnumerator = securityElementObj.Attributes.GetEnumerator();
			while(attributeEnumerator.MoveNext())
			Console.WriteLine("Attribute - \"{0}\" , Value - \"{1}\"", ((IDictionaryEnumerator)attributeEnumerator).Key, 
																	((IDictionaryEnumerator)attributeEnumerator).Value); 
		}

		Console.WriteLine("");

		if(securityElementObj.Children != null) {
			depth += 1;
			for(int i = 0; i < securityElementObj.Children.Count; i++) 
				PrintSecurityElement((SecurityElement)(securityElementObj.Children[i]), depth);
		}
	}

	public String GetDate() 
	{

		SocketPermission socketPermission1 = new SocketPermission(PermissionState.Unrestricted);

		// Create a 'SocketPermission' object for two ip addresses.
		SocketPermission socketPermission2 = new SocketPermission(PermissionState.None);
		SecurityElement securityElement4 = socketPermission2.ToXml();
      // 'SocketPermission' object for 'Connect' permission
		SecurityElement securityElement1 = new SecurityElement("ConnectAccess");
      // Format to specify ip address are <ip-address>#<port>#<transport-type>
		// First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
		SecurityElement securityElement2 = new SecurityElement("URI", "192.168.144.238#-1#3");
      // Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
		SecurityElement securityElement3 = new SecurityElement("URI", "192.168.144.240#-1#3");
		securityElement1.AddChild(securityElement2);
		securityElement1.AddChild(securityElement3);
		securityElement4.AddChild(securityElement1);
		
	   // Obtain a 'SocketPermission' object using 'FromXml' method.	
		socketPermission2.FromXml(securityElement4);

		// Create another 'SocketPermission' object with two ip addresses.
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
		SocketPermission socketPermission3 = 
						new SocketPermission(NetworkAccess.Connect,
											 TransportType.All,
											 "192.168.144.238",
											 SocketPermission.AllPorts);

      // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
		socketPermission3.AddPermission(NetworkAccess.Connect,
									   TransportType.All,
									   "192.168.144.239",
									   SocketPermission.AllPorts);

		Console.WriteLine("\nChecks the Socket permissions using IsUnrestricted method : ");
		if(socketPermission1.IsUnrestricted())
			Console.WriteLine("Socket permission is unrestricted");
		else
			Console.WriteLine("Socket permission is restricted");

		Console.WriteLine();

		Console.WriteLine("Display result of ConnectList property : \n");
		IEnumerator enumerator = socketPermission3.ConnectList;
		while(enumerator.MoveNext()) {
			Console.WriteLine("The hostname is       : {0}", ((EndpointPermission)enumerator.Current).Hostname);
			Console.WriteLine("The port is           : {0}", ((EndpointPermission)enumerator.Current).Port);
			Console.WriteLine("The Transport type is : {0}", ((EndpointPermission)enumerator.Current).Transport);
		}
		Console.WriteLine("");

		Console.WriteLine("Display Security Elements :\n ");
		PrintSecurityElement(socketPermission2.ToXml(), 0);

		// Get a 'SocketPermission' object which is a union of two other 'SocketPermission' objects.
		socketPermission1 = (SocketPermission)socketPermission3.Union(socketPermission2);

		// Demand that the calling method have the socket permission.
		socketPermission1.Demand();

		// Get the current date from the remote date server.
		try {
			int bytesReceived;		
			byte[] getByte = new byte[100];
			serverSocket.Connect(new IPEndPoint( serverAddress, serverPort));
			bytesReceived = serverSocket.Receive( getByte, getByte.Length, 0 );
			return asciiEncoding.GetString( getByte, 0, bytesReceived );
		}
		catch(Exception e)
		{
			Console.WriteLine("\nException raised : {0}", e.Message);
			return "";
		}
	}
};
// </Snippet3>
// </Snippet2>
// </Snippet1>

// This class is used to demonstrate the caller of the 'GetDate' method for the 'DateClient' object.
public class UserDateClient {

	public static void Main(String[] args) {
		if(args.Length != 2) 
		{
			PrintUsage();
			return;
		}	
		try {
			DateClient myDateClient = new DateClient(IPAddress.Parse(args[0]), Int32.Parse(args[1]));
			String currentDate = myDateClient.GetDate();
			Console.WriteLine("The current date and time is : ");
			Console.WriteLine("{0}", currentDate); 
		}
		// This exception is thrown by the called method in the context of improper permissions.
		catch(SecurityException e) {
			Console.WriteLine("\nSecurityException raised : {0}", e.Message);
		}
		catch(Exception e) {
			Console.WriteLine("\nException raised : {0}", e.Message);
		}
	}
	
	private static void PrintUsage() {
		Console.WriteLine("Usage : DateClient_SocketPermission_ToXml");
		Console.WriteLine("\tDateClient_SocketPermission_ToXml <ipaddress> <port>");
		Console.WriteLine("\tThe ipaddress argument is the ip address of the Date server.");
		Console.WriteLine("\tThe port argument is the port of the Date server.");
	}
};
