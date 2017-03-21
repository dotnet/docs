      String^ uriString;
      Console::Write( "\nPlease enter the URI to post data to: " );
      uriString = Console::ReadLine();
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      // Apply Ascii Encoding to obtain an array of bytes.
      array<Byte>^ postArray = Encoding::ASCII->GetBytes( postData );
      
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      
      // postStream implicitly sets HTTP POST as the request method.
      Console::WriteLine( "Uploading to {0} ...", uriString );
      Stream^ postStream = myWebClient->OpenWrite( uriString );

      postStream->Write( postArray, 0, postArray->Length );
      
      // Close the stream and release resources.
      postStream->Close();

      Console::WriteLine( "\nSuccessfully posted the data." );