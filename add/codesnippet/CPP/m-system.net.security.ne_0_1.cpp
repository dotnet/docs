   // The following method is called when the write operation completes.
   static void EndWriteCallback( IAsyncResult^ ar )
   {
      Console::WriteLine( L"Client ending write operation..." );
      NegotiateStream^ authStream = dynamic_cast<NegotiateStream^>(ar->AsyncState);
      
      // End the asynchronous operation.
      authStream->EndWrite( ar );
   }
