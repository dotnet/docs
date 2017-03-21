      // Establish the remote endpoint for the socket.
      // For this example, use the local machine.
      IPHostEntry^ ipHostInfo = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddress = ipHostInfo->AddressList[ 0 ];
      
      // Client and server use port 11000. 
      IPEndPoint^ remoteEP = gcnew IPEndPoint( ipAddress,11000 );
      
      // Create a TCP/IP socket.
      client = gcnew TcpClient;
      
      // Connect the socket to the remote endpoint.
      client->Connect( remoteEP );
      Console::WriteLine( L"Client connected to {0}.", remoteEP );
      
      // Ensure the client does not close when there is 
      // still data to be sent to the server.
      client->LingerState = (gcnew LingerOption( true,0 ));
      
      // Request authentication.
      NetworkStream^ clientStream = client->GetStream();
      NegotiateStream^ authStream = gcnew NegotiateStream( clientStream,false );
      
      // Pass the NegotiateStream as the AsyncState object 
      // so that it is available to the callback delegate.
      IAsyncResult^ ar = authStream->BeginAuthenticateAsClient( gcnew AsyncCallback( EndAuthenticateCallback ), authStream );
      