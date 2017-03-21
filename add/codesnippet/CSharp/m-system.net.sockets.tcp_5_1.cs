              
      try{
              // Use the Pending method to poll the underlying socket instance for client connection requests.
  				IPAddress ipAddress = Dns.Resolve("localhost").AddressList[0];
           	TcpListener tcpListener =  new TcpListener(ipAddress, portNumber); 
           	tcpListener.Start();
           	
		    	if (!tcpListener.Pending()) {

		    	Console.WriteLine("Sorry, no connection requests have arrived");
		    	
		     }
		     else{

                   //Accept the pending client connection and return a TcpClient object initialized for communication.
                   TcpClient tcpClient = tcpListener.AcceptTcpClient();
                   // Using the RemoteEndPoint property.
                   Console.WriteLine("I am listening for connections on " + 
                                               IPAddress.Parse(((IPEndPoint)tcpListener.LocalEndpoint).Address.ToString()) +
      	                                        "on port number " + ((IPEndPoint)tcpListener.LocalEndpoint).Port.ToString());
