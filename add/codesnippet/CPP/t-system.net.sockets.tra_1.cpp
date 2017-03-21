      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // Create a TCP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote endpoint.
      client->Connect( ipEndPoint );

      // Send file fileName to the remote host with preBuffer and postBuffer data.
      // There is a text file test.txt located in the root directory.
      String^ fileName = "C:\\test.txt";

      // Create the preBuffer data.
      String^ string1 = String::Format( "This is text data that precedes the file.{0}", Environment::NewLine );
      array<Byte>^preBuf = Encoding::ASCII->GetBytes( string1 );

      // Create the postBuffer data.
      String^ string2 = String::Format( "This is text data that will follow the file.{0}", Environment::NewLine );
      array<Byte>^postBuf = Encoding::ASCII->GetBytes( string2 );

      //Send file fileName with buffers and default flags to the remote device.
      Console::WriteLine( "Sending {0} with buffers to the host.{1}", fileName, Environment::NewLine );
      client->SendFile( fileName, preBuf, postBuf, TransmitFileOptions::UseDefaultWorkerThread );

      // Release the socket.
      client->Shutdown( SocketShutdown::Both );
      client->Close();