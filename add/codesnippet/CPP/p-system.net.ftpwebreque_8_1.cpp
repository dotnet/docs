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