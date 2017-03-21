   IDictionary^ prop = gcnew Hashtable;
   prop[ "port" ] = 9000;
   IClientChannelSinkProvider^ clientChain = gcnew BinaryClientFormatterSinkProvider;
   IServerChannelSinkProvider^ serverChain = gcnew SoapServerFormatterSinkProvider;
   serverChain->Next = gcnew BinaryServerFormatterSinkProvider;
   ChannelServices::RegisterChannel( gcnew HttpChannel( prop,clientChain,serverChain ) );