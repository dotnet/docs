   void ReadCallback( IAsyncResult^ ar )
   {
      ClientState^ state = dynamic_cast<ClientState^>(ar->AsyncState);
      SslStream^ stream = state->stream;
      
      // Read the  message sent by the client.
      // The end of the message is signaled using the
      // "<EOF>" marker.
      int byteCount = -1;
      try
      {
         Console::WriteLine( L"Reading data from the client." );
         byteCount = stream->EndRead( ar );
         
         // Use Decoder class to convert from bytes to UTF8
         // in case a character spans two buffers.
         Decoder^ decoder = Encoding::UTF8->GetDecoder();
         array<Char>^chars = gcnew array<Char>(decoder->GetCharCount( state->buffer, 0, byteCount ));
         decoder->GetChars( state->buffer, 0, byteCount, chars, 0 );
         state->readData->Append( chars );
         
         // Check for EOF or an empty message.
         if ( state->readData->ToString()->IndexOf( L"<EOF>" ) == -1 && byteCount != 0 )
         {
            
            // We are not finished reading.
            // Asynchronously read more message data from  the client.
            stream->BeginRead( state->buffer, 0, state->buffer->Length, gcnew AsyncCallback( this, &SslTcpListener::ReadCallback ), state );
         }
         else
         {
            Console::WriteLine( L"Message from the client: {0}", state->readData );
         }
         
         // Encode a test message into a byte array.
         // Signal the end of the message using "<EOF>".
         array<Byte>^message = Encoding::UTF8->GetBytes( L"Hello from the server.<EOF>" );
         
         // Asynchronously send the message to the client.
         stream->BeginWrite( message, 0, message->Length, gcnew AsyncCallback( this, &SslTcpListener::WriteCallback ), state );
      }
      catch ( Exception^ readException ) 
      {
         Console::WriteLine( L"Read error: {0}", readException->Message );
         state->Close();
         return;
      }

   }

