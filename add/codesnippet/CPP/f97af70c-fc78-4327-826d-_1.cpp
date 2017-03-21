   // Parse the channel's URI.
   String^ objectUrl = L"http://localhost:9090/RemoteObject.rem";
   String^ channelUri = clientChannel->Parse( objectUrl,  objectUri );
   Console::WriteLine( L"The object URL is {0}.", objectUrl );
   Console::WriteLine( L"The object URI is {0}.", objectUri );
   Console::WriteLine( L"The channel URI is {0}.", channelUri );