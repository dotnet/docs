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