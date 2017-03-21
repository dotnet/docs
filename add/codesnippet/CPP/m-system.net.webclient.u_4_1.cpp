      Console::Write( "\nPlease enter the URI to post data to: " );
      String^ uriString = Console::ReadLine();
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      // Apply ASCII Encoding to obtain the String* as a Byte array.
      array<Byte>^ postArray = Encoding::ASCII->GetBytes( postData );
      Console::WriteLine( "Uploading to {0} ...", uriString );
      myWebClient->Headers->Add( "Content-Type", "application/x-www-form-urlencoded" );
      
      //UploadData implicitly sets HTTP POST as the request method.
      array<Byte>^responseArray = myWebClient->UploadData( uriString, postArray );
      
      // Decode and display the response.
      Console::WriteLine( "\nResponse received was: {0}", Encoding::ASCII->GetString( responseArray ) );