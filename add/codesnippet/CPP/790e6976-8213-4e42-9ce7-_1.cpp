   // Create the server channel.
   String^ name = L"ipc";
   String^ portName = L"localhost:9090";
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( name,portName,sinkProvider );
   