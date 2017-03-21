   System::Collections::Hashtable^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"port" ] = 9090;
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( properties,sinkProvider );
   