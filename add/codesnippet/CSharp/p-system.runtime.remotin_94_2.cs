        ChannelServices.RegisterChannel(new TcpChannel());

        RemotingConfiguration.RegisterWellKnownClientType(
                                                           typeof(HelloService),
                                                           "tcp://localhost:8082/HelloServiceApplication/MyUri"
                                                         );

        HelloService service = new HelloService();