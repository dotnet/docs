   static void AuthenticateClient( TcpClient^ clientRequest )
   {
      NetworkStream^ stream = clientRequest->GetStream();
      
      // Create the NegotiateStream.
      NegotiateStream^ authStream = gcnew NegotiateStream( stream,false );
      
      // Save the current client and NegotiateStream instance 
      // in a ClientState object.
      ClientState^ cState = gcnew ClientState( authStream,clientRequest );
      
      // Listen for the client authentication request.
      authStream->BeginAuthenticateAsServer( gcnew AsyncCallback( EndAuthenticateCallback ), cState );
      
      // Wait until the authentication completes.
      cState->Waiter->WaitOne();
      cState->Waiter->Reset();
      authStream->BeginRead( cState->Buffer, 0, cState->Buffer->Length, gcnew AsyncCallback( EndReadCallback ), cState );
      cState->Waiter->WaitOne();
      
      // Finished with the current client.
      authStream->Close();
      clientRequest->Close();
   }

