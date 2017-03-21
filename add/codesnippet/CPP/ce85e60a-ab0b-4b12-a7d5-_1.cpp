         DiscoveryExceptionDictionary^ myNewExceptionDictionary = gcnew DiscoveryExceptionDictionary;
         
         // Add an exception with the custom error message.
         Exception^ myNewException = gcnew Exception( "The requested service is not available." );
         myNewExceptionDictionary->Add( myUrlKey, myNewException );
         myExceptionDictionary = myNewExceptionDictionary;