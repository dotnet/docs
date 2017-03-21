      Dim channel As New HttpChannel(9000)
      ChannelServices.RegisterChannel(channel)
      RemotingConfiguration.RegisterWellKnownServiceType(GetType(SampleService), "MySampleService/SampleService.soap", WellKnownObjectMode.Singleton)
      
      Console.WriteLine("** Press enter to end the server process. **")
      Console.ReadLine()