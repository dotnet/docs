      String^ uriString;
      Console::Write( "\nPlease enter the URI to post data to {for example, http://www.contoso.com}: " );
      uriString = Console::ReadLine();

      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      Console::WriteLine( "\nPlease enter the data to be posted to the URI {0}:", uriString );
      String^ postData = Console::ReadLine();
      myWebClient->Headers->Add( "Content-Type", "application/x-www-form-urlencoded" );

      // Displays the headers in the request
      Console::Write( "Resulting Request Headers: ");
      Console::WriteLine(myWebClient->Headers);
      
      // Apply ASCII Encoding to obtain the String^ as a Byte array.
      array<Byte>^ byteArray = Encoding::ASCII->GetBytes( postData );
      Console::WriteLine( "Uploading to {0} ...", uriString );
      // Upload the input String* using the HTTP 1.0 POST method.
      array<Byte>^responseArray = myWebClient->UploadData( uriString, "POST", byteArray );
      // Decode and display the response.
      Console::WriteLine( "\nResponse received was {0}",
         Encoding::ASCII->GetString( responseArray ) );