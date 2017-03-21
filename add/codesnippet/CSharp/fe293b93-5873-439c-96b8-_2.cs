        ChannelServices.RegisterChannel(new TcpChannel(8082));

        RemotingConfiguration.ApplicationName = "HelloServiceApplication";

        RemotingConfiguration.RegisterWellKnownServiceType( typeof(HelloService),
                                                            "MyUri",
                                                            WellKnownObjectMode.SingleCall 
                                                          );