   static void EndAuthenticateCallback( IAsyncResult^ ar )
   {
      
      // Get the saved data.
      ClientState^ cState = dynamic_cast<ClientState^>(ar->AsyncState);
      TcpClient^ clientRequest = cState->Client;
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(cState->AuthStream);
      Console::WriteLine( L"Ending authentication." );
      
      // Any exceptions that occurred during authentication are
      // thrown by the EndServerAuthenticate method.
      try
      {
         
         // This call blocks until the authentication is complete.
         authStream->EndAuthenticateAsServer( ar );
      }
      catch ( AuthenticationException^ e ) 
      {
         Console::WriteLine( e );
         Console::WriteLine( L"Authentication failed - closing connection." );
         cState->Waiter->Set();
         return;
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
         Console::WriteLine( L"Closing connection." );
         cState->Waiter->Set();
         return;
      }

      
      // Display properties of the authenticated client.
      IIdentity^ id = authStream->RemoteIdentity;
      Console::WriteLine( L"{0} was authenticated using {1}.", id->Name, id->AuthenticationType );
      cState->Waiter->Set();
   }

