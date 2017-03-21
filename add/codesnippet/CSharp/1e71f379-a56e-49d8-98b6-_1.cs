		SocketPermission socketPermission1 = new SocketPermission(PermissionState.Unrestricted);

		// Create a 'SocketPermission' object for two ip addresses.
		SocketPermission socketPermission2 = new SocketPermission(PermissionState.None);
		SecurityElement securityElement1 = socketPermission2.ToXml();
		// 'SocketPermission' object for 'Connect' permission
		SecurityElement securityElement2 = new SecurityElement("ConnectAccess");
		// Format to specify ip address are <ip-address>#<port>#<transport-type>
		// First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and 
      // for 'All'ports for the ip-address.
		SecurityElement securityElement3 = new SecurityElement("URI", "192.168.144.238#-1#3");
		// Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and 
      // for 'All' ports for the ip-address.
		SecurityElement securityElement4 = new SecurityElement("URI", "192.168.144.240#-1#3");
		securityElement2.AddChild(securityElement3);
		securityElement2.AddChild(securityElement4);
		securityElement1.AddChild(securityElement2);
		
	   // Obtain a 'SocketPermission' object using 'FromXml' method.
		socketPermission2.FromXml(securityElement1);

		Console.WriteLine("\nDisplays the result of FromXml method : \n");
		Console.WriteLine(socketPermission2.ToString());

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

		Console.WriteLine("Displays the result of AddPermission method : \n");
		Console.WriteLine(socketPermission3.ToString());

	   // Find the intersection between two 'SocketPermission' objects.
		socketPermission1 = (SocketPermission)socketPermission2.Intersect(socketPermission3);

		Console.WriteLine("Displays the result of Intersect method :\n ");
		Console.WriteLine(socketPermission1.ToString());

		// Demand that the calling method have the requsite socket permission.
		socketPermission1.Demand();