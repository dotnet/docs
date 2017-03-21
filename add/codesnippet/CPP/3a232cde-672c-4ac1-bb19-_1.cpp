   // Create a client channel.
   System::Collections::Hashtable^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"port" ] = 9090;
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   HttpClientChannel^ clientChannel = gcnew HttpClientChannel( properties,sinkProvider );
   