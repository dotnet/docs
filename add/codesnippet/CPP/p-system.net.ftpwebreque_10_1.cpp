private:
   // DisplayRequestProperties prints a request's properties.
   // This method should be called after the request is sent to the server.
   static void DisplayRequestProperties( FtpWebRequest^ request )
   {
      Console::WriteLine( "User {0} {1}", request->Credentials->GetCredential( request->RequestUri, "basic" )->UserName, request->RequestUri );

      Console::WriteLine( "Request: {0} {1}", request->Method, request->RequestUri );

      Console::WriteLine( "Passive: {0}  Keep alive: {1}  Binary: {2} Timeout: {3}.", request->UsePassive, request->KeepAlive, request->UseBinary, request->Timeout == -1 ? "none" : request->Timeout.ToString() );

      IWebProxy^ proxy = request->Proxy;
      if ( proxy )
      {
         Console::WriteLine( "Proxy: {0}", proxy->GetProxy( request->RequestUri ) );
      }
      else
      {
         Console::WriteLine( "Proxy: (none)" );
      }

      Console::WriteLine( "ConnectionGroup: {0}", request->ConnectionGroupName == nullptr ? "none" : request->ConnectionGroupName );

      Console::WriteLine( "Encrypted connection: {0}", request->EnableSsl );

      Console::WriteLine("Method: {0}", request->Method);
   }