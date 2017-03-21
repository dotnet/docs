      Console::Write( "\nPlease enter a URI (e.g. http://www.contoso.com): " );
      String^ remoteUri = Console::ReadLine();
      
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      // Download home page data.
      Console::WriteLine( "Downloading {0}", remoteUri );
      // Download the Web resource and save it into a data buffer.
      array<Byte>^ myDataBuffer = myWebClient->DownloadData( remoteUri );
      
      // Display the downloaded data.
      String^ download = Encoding::ASCII->GetString( myDataBuffer );
      Console::WriteLine( download );

      Console::WriteLine( "Download successful." );