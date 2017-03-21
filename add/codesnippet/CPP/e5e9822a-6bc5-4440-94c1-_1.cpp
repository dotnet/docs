   // Create the client channel.
   System::Collections::IDictionary^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"name" ] = L"ipc client";
   properties->default[ L"priority" ] = L"1";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   IpcClientChannel^ clientChannel = gcnew IpcClientChannel( properties,sinkProvider );