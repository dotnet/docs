   HttpChannel^ myClientChannel = gcnew HttpChannel( myProperties,gcnew SoapClientFormatterSinkProvider,gcnew SoapServerFormatterSinkProvider );
   ChannelServices::RegisterChannel( myClientChannel, false );
   
   // Get the registered channel. 
   Console::WriteLine( "Channel Name : {0}", ChannelServices::GetChannel( myClientChannel->ChannelName )->ChannelName );
   Console::WriteLine( "Channel Priorty : {0}", ChannelServices::GetChannel( myClientChannel->ChannelName )->ChannelPriority );
   