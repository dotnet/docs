
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
		      Console.WriteLine("\nException thrown.\nThe Original Message is: "+e.Message);
		      // Throw the 'WebException' object with a message string and message status specific to the situation.
		      throw new WebException("Unable to locate the Server with 'www.contoso.com' Uri.",WebExceptionStatus.NameResolutionFailure);
		  }