   static void ProcessClient( TcpClient^ client )
   {
      
      // A client has connected. Create the 
      // SslStream using the client's network stream.
      SslStream^ sslStream = gcnew SslStream( client->GetStream(),false );
      
      // Authenticate the server but don't require the client to authenticate.
      try
      {
         sslStream->AuthenticateAsServer( serverCertificate, false, 
             SslProtocols::Tls, true );
         
         // Display the properties and settings for the authenticated stream.
         DisplaySecurityLevel( sslStream );
         DisplaySecurityServices( sslStream );
         DisplayCertificateInformation( sslStream );
         DisplayStreamProperties( sslStream );
         
         // Set timeouts for the read and write to 5 seconds.
         sslStream->ReadTimeout = 5000;
         sslStream->WriteTimeout = 5000;
         
         // Read a message from the client.   
         Console::WriteLine( L"Waiting for client message..." );
         String^ messageData = ReadMessage( sslStream );
         Console::WriteLine( L"Received: {0}", messageData );
         
         // Write a message to the client.
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the server.<EOF>" );
         Console::WriteLine( L"Sending hello message." );
         sslStream->Write( message );
      }
      catch ( AuthenticationException^ e ) 
      {
         Console::WriteLine( L"Exception: {0}", e->Message );
         if ( e->InnerException != nullptr )
         {
            Console::WriteLine( L"Inner exception: {0}", e->InnerException->Message );
         }
         Console::WriteLine( L"Authentication failed - closing the connection." );
         sslStream->Close();
         client->Close();
         return;
      }
      finally
      {
         
         // The client stream will be closed with the sslStream
         // because we specified this behavior when creating
         // the sslStream.
         sslStream->Close();
         client->Close();
      }

   }

