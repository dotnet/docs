   // Create the server channel.
   String^ name = L"ipc";
   String^ portName = L"localhost:9090";
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( name,portName );
   