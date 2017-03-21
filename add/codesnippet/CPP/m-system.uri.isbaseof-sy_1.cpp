   // Create a base Uri.
   Uri^ baseUri = gcnew Uri( "http://www.contoso.com/" );

   // Create a new Uri from a string.
   Uri^ uriAddress = gcnew Uri( "http://www.contoso.com/index.htm?date=today" );

   // Determine whether BaseUri is a base of UriAddress.  
   if ( baseUri->IsBaseOf( uriAddress ) )
      Console::WriteLine( "{0} is the base of {1}", baseUri, uriAddress );