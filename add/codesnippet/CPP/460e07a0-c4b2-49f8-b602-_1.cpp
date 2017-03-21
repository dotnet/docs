   String^ name = L"RemotingServer";
   int port = 9090;
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel(
      name,port,sinkProvider );
   