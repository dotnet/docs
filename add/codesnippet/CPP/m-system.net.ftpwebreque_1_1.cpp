private:
   static void EndGetStreamCallback( IAsyncResult^ ar )
   {
      FtpState^ state = dynamic_cast<FtpState^>(ar->AsyncState);
      Stream^ requestStream = nullptr;

      // End the asynchronous call to get the request stream.
      try
      {
         requestStream = state->Request->EndGetRequestStream( ar );

         // Copy the file contents to the request stream.
         const int bufferLength = 2048;
         array<Byte>^buffer = gcnew array<Byte>(bufferLength);
         int count = 0;
         int readBytes = 0;
         FileStream^ stream = File::OpenRead( state->FileName );
         do
         {
            readBytes = stream->Read( buffer, 0, bufferLength );
            requestStream->Write( buffer, 0, bufferLength );
            count += readBytes;
         }
         while ( readBytes != 0 );
         Console::WriteLine( "Writing {0} bytes to the stream.", count );

         // IMPORTANT: Close the request stream before sending the request.
         requestStream->Close();

         // Asynchronously get the response to the upload request.
         state->Request->BeginGetResponse( gcnew AsyncCallback( EndGetResponseCallback ), state );
      }
      // Return exceptions to the main application thread.
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Could not get the request stream." );
         state->OperationException = e;
         state->OperationComplete->Set();
         return;
      }
   }