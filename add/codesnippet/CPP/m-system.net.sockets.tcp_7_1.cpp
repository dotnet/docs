         // Accepts the pending client connection and returns a socket for communciation.
         Socket^ socket = tcpListener->AcceptSocket();
         Console::WriteLine( "Connection accepted." );

         String^ responseString = "You have successfully connected to me";
         
         //Forms and sends a response string to the connected client.
         array<Byte>^sendBytes = Encoding::ASCII->GetBytes( responseString );
         int i = socket->Send( sendBytes );
         Console::WriteLine( "Message Sent /> : {0}", responseString );