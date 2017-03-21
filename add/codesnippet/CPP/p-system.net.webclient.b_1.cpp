      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      
      // Set the BaseAddress of the Web Resource in the WebClient.
      myWebClient->BaseAddress = hostUri;
      Console::WriteLine( "Downloading from {0}/ {1}", hostUri, uriSuffix );
      Console::WriteLine( "\nPress Enter key to continue" );
      Console::ReadLine();
      
      // Download the target Web Resource into a Byte array.
      array<Byte>^ myDatabuffer = myWebClient->DownloadData( uriSuffix );
      
      // Display the downloaded data.
      String^ download = Encoding::ASCII->GetString( myDatabuffer );
      Console::WriteLine( download );
      Console::WriteLine( "Download of {0}{1} was successful.", myWebClient->BaseAddress, uriSuffix );