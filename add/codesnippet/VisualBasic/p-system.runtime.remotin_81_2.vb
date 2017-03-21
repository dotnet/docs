      ChannelServices.RegisterChannel(New TcpChannel())
      
      RemotingConfiguration.RegisterWellKnownClientType(GetType(HelloService), "tcp://localhost:8082/HelloServiceApplication/MyUri")
      
      Dim service As New HelloService()