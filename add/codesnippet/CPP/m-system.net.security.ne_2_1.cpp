   static void EndReadCallback( IAsyncResult^ ar )
   {
      
      // Get the saved data.
      ClientState^ cState = dynamic_cast<ClientState^>(ar->AsyncState);
      TcpClient^ clientRequest = cState->Client;
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(cState->AuthStream);
      
      // Get the buffer that stores the message sent by the client.
      int bytes = -1;
      
      // Read the client message.
      try
      {
         bytes = authStream->EndRead( ar );
         cState->Message->Append( Encoding::UTF8->GetChars( cState->Buffer, 0, bytes ) );
         if ( bytes != 0 )
         {
            authStream->BeginRead( cState->Buffer, 0, cState->Buffer->Length, gcnew AsyncCallback( EndReadCallback ), cState );
            return;
         }
      }
      catch ( Exception^ e ) 
      {
         
         // A real application should do something
         // useful here, such as logging the failure.
         Console::WriteLine( L"Client message exception:" );
         Console::WriteLine( e );
         cState->Waiter->Set();
         return;
      }

      IIdentity^ id = authStream->RemoteIdentity;
      Console::WriteLine( L"{0} says {1}", id->Name, cState->Message );
      cState->Waiter->Set();
   }
