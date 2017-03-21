   static void WriteCallback( IAsyncResult^ ar )
   {
      SslStream^ stream = dynamic_cast<SslStream^>(ar->AsyncState);
      try
      {
         Console::WriteLine( L"Writing data to the server." );
         stream->EndWrite( ar );
         
         // Asynchronously read a message from the server.
         stream->BeginRead( buffer, 0, buffer->Length, gcnew AsyncCallback( ReadCallback ), stream );
      }
      catch ( Exception^ writeException ) 
      {
         e = writeException;
         complete = true;
         return;
      }

   }

