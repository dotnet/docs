   // Create UrlAttribute.
   UrlAttribute^ attribute = gcnew UrlAttribute( "tcp://localhost:1234/RemoteApp" );
   Console::WriteLine( "UrlAttribute value: {0}", attribute->UrlValue );
   