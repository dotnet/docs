   void WriteCallback( IAsyncResult^ ar )
   {
      ClientState^ state = dynamic_cast<ClientState^>(ar->AsyncState);
      SslStream^ stream = state->stream;
      try
      {
         Console::WriteLine( L"Writing data to the client." );
         stream->EndWrite( ar );
      }
      catch ( Exception^ writeException ) 
      {
         Console::WriteLine( L"Write error: {0}", writeException->Message );
         state->Close();
         return;
      }

      Console::WriteLine( L"Finished with client." );
      state->Close();
   }

