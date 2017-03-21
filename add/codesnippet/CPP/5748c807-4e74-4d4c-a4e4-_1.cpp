      // Request authentication.
      NetworkStream^ clientStream = client->GetStream();
      NegotiateStream^ authStream = gcnew NegotiateStream( clientStream,false );
      
      // Pass the NegotiateStream as the AsyncState object 
      // so that it is available to the callback delegate.
      IAsyncResult^ ar = authStream->BeginAuthenticateAsClient( gcnew AsyncCallback( EndAuthenticateCallback ), authStream );
      
      Console::WriteLine( L"Client waiting for authentication..." );
      
      // Wait until the result is available.
      ar->AsyncWaitHandle->WaitOne();
      
      // Display the properties of the authenticated stream.
      AuthenticatedStreamReporter::DisplayProperties( authStream );
      
      // Send a message to the server.
      // Encode the test data into a byte array.
      array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the client." );
      ar = authStream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( EndWriteCallback ), authStream );
      