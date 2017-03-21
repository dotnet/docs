   static void AuthenticateCallback( IAsyncResult^ ar )
   {
      SslStream^ stream = dynamic_cast<SslStream^>(ar->AsyncState);
      try
      {
         stream->EndAuthenticateAsClient( ar );
         Console::WriteLine( L"Authentication succeeded." );
         Console::WriteLine( L"Cipher: {0} strength {1}", stream->CipherAlgorithm, stream->CipherStrength );
         Console::WriteLine( L"Hash: {0} strength {1}", stream->HashAlgorithm, stream->HashStrength );
         Console::WriteLine( L"Key exchange: {0} strength {1}", stream->KeyExchangeAlgorithm, stream->KeyExchangeStrength );
         Console::WriteLine( L"Protocol: {0}", stream->SslProtocol );
         
         // Encode a test message into a byte array.
         // Signal the end of the message using the "<EOF>".
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the client.<EOF>" );
         
         // Asynchronously send a message to the server.
         stream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( WriteCallback ), stream );
      }
      catch ( Exception^ authenticationException ) 
      {
         e = authenticationException;
         complete = true;
         return;
      }

   }

