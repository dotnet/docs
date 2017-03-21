   // Example of EndRead, DataAvailable and BeginRead.
   static void myReadCallBack( IAsyncResult^ ar )
   {
      NetworkStream^ myNetworkStream = safe_cast<NetworkStream^>(ar->AsyncState);
      array<Byte>^myReadBuffer = gcnew array<Byte>(1024);
      String^ myCompleteMessage = "";
      int numberOfBytesRead;
      numberOfBytesRead = myNetworkStream->EndRead( ar );
      myCompleteMessage = String::Concat( myCompleteMessage, Encoding::ASCII->GetString( myReadBuffer, 0, numberOfBytesRead ) );
      
      // message received may be larger than buffer size so loop through until you have it all.
      while ( myNetworkStream->DataAvailable )
      {
         AsyncCallback^ pasync = gcnew AsyncCallback( &myReadCallBack );
         myNetworkStream->BeginRead( myReadBuffer, 0, myReadBuffer->Length, pasync, myNetworkStream );
      }

      // Print out the received message to the console.
      Console::WriteLine( "You received the following message : {0}", myCompleteMessage );
   }