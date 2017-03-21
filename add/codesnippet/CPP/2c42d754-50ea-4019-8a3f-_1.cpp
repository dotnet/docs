   // Create a client channel.
   String^ name = L"RemotingClient";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   HttpClientChannel^ clientChannel = gcnew HttpClientChannel( name,sinkProvider );
   