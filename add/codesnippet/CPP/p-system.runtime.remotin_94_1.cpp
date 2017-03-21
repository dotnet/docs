   ChannelServices::RegisterChannel( gcnew TcpChannel( 8082 ) );
   RemotingConfiguration::ApplicationName = "HelloServiceApplication";
   RemotingConfiguration::RegisterWellKnownServiceType( HelloService::typeid,
                                                        "MyUri",
                                                        WellKnownObjectMode::SingleCall );