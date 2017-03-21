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