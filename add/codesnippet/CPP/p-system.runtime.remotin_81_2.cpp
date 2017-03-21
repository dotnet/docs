   ChannelServices::RegisterChannel( gcnew TcpChannel );
   RemotingConfiguration::RegisterWellKnownClientType( HelloService::typeid,
                                                       "tcp://localhost:8082/HelloServiceApplication/MyUri" );
   HelloService ^ service = gcnew HelloService;