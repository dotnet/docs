      TcpClient^ tcpClient = gcnew TcpClient;
      
      // Uses the GetStream public method to return the NetworkStream.
      NetworkStream^ netStream = tcpClient->GetStream();
      if ( netStream->CanWrite )
      {
         array<Byte>^sendBytes = Encoding::UTF8->GetBytes( "Is anybody there?" );
         netStream->Write( sendBytes, 0, sendBytes->Length );
      }
      else
      {
         Console::WriteLine( "You cannot write data to this stream." );
         tcpClient->Close();
         
         // Closing the tcpClient instance does not close the network stream.
         netStream->Close();
         return;
      }

      if ( netStream->CanRead )
      {
         
         // Reads NetworkStream into a byte buffer.
         array<Byte>^bytes = gcnew array<Byte>(tcpClient->ReceiveBufferSize);
         
         // Read can return anything from 0 to numBytesToRead. 
         // This method blocks until at least one byte is read.
         netStream->Read( bytes, 0, (int)tcpClient->ReceiveBufferSize );
         
         // Returns the data received from the host to the console.
         String^ returndata = Encoding::UTF8->GetString( bytes );
         Console::WriteLine( "This is what the host returned to you: {0}", returndata );
      }
      else
      {
         Console::WriteLine( "You cannot read data from this stream." );
         tcpClient->Close();
         
         // Closing the tcpClient instance does not close the network stream.
         netStream->Close();
         return;
      }

      