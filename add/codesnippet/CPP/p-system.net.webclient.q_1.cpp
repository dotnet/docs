      String^ uriString = "http://www.contoso.com/search";
      // Create a new WebClient instance.
      WebClient^ myWebClient = gcnew WebClient;
      // Create a new NameValueCollection instance to hold the QueryString parameters and values.
      NameValueCollection^ myQueryStringCollection = gcnew NameValueCollection;
      Console::Write( "Enter the word(s), separated by space character to search for in {0}: ", uriString );
      // Read user input phrase to search for at uriString.
      String^ searchPhrase = Console::ReadLine();
      if ( searchPhrase->Length > 1 )
      {
         // Assign the user-defined search phrase.
         myQueryStringCollection->Add( "q", searchPhrase );
      }
      else
      {
         // If error, default to search for 'Microsoft'.
         myQueryStringCollection->Add( "q", "Microsoft" );
      }
      // Assign auxilliary parameters required for the search.
      Console::WriteLine( "Searching {0} .......", uriString );
      // Attach QueryString to the WebClient.
      myWebClient->QueryString = myQueryStringCollection;
      // Download the search results Web page into 'searchresult.htm' for inspection.
      myWebClient->DownloadFile( uriString, "searchresult.htm" );
      Console::WriteLine( "\nDownload of {0} was successful. Please see 'searchresult.htm' for results.", uriString );