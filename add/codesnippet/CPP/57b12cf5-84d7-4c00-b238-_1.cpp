   String^ name = L"RemotingServer";
   int port = 9090;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( name,port );
   