      //Creates a UdpClient for reading incoming data.
      UdpClient^ receivingUdpClient = gcnew UdpClient( 11000 );
      
      //Creates an IPEndPoint to record the IP Address and port number of the sender. 
      // The IPEndPoint will allow you to read datagrams sent from any source.
      IPEndPoint^ RemoteIpEndPoint = gcnew IPEndPoint( IPAddress::Any,0 );
      try
      {
         // Blocks until a message returns on this socket from a remote host.
         array<Byte>^receiveBytes = receivingUdpClient->Receive(  RemoteIpEndPoint );

         String^ returnData = Encoding::ASCII->GetString( receiveBytes );

         Console::WriteLine( "This is the message you received {0}", returnData );
         Console::WriteLine( "This message was sent from {0} on their port number {1}",
            RemoteIpEndPoint->Address, RemoteIpEndPoint->Port );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }