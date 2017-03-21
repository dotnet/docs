   // Show the URIs associated with the channel.
   System::Runtime::Remoting::Channels::ChannelDataStore^ channelData = 
      static_cast<System::Runtime::Remoting::Channels::ChannelDataStore^>
         (serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = channelData->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>( myEnum->Current );
      Console::WriteLine( L"The channel URI is {0}.",uri );
   }