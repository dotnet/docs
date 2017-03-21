   // Show the URIs associated with the channel.
   System::Runtime::Remoting::Channels::ChannelDataStore^ channelData = (System::Runtime::Remoting::Channels::ChannelDataStore^)serverChannel->ChannelData;
   for each (String^ uri in channelData->ChannelUris)
   {
      Console::WriteLine("The channel URI is {0}.", uri);
   }