      ChannelServices.RegisterChannel(New TcpChannel(8082))
      
      RemotingConfiguration.ApplicationName = "HelloServiceApplication"
      
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(HelloService), "MyUri", WellKnownObjectMode.SingleCall)