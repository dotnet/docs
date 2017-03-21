
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