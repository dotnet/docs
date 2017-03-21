   // Create the client channel.
   String^ name = L"ipc client";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   IpcClientChannel^ clientChannel = gcnew IpcClientChannel( name,sinkProvider );