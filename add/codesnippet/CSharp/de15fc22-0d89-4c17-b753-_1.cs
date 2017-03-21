        HttpChannel channel = new HttpChannel(9000);
        ChannelServices.RegisterChannel(channel);

        RemotingConfiguration.RegisterWellKnownServiceType( typeof(SampleService), 
		"MySampleService/SampleService.soap", WellKnownObjectMode.Singleton);
        
        Console.WriteLine("** Press enter to end the server process. **");
        Console.ReadLine();