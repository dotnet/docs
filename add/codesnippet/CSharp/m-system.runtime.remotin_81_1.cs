      TcpChannel channel = new TcpChannel(9000);
      ChannelServices.RegisterChannel(channel);

      SampleWellKnown objectWellKnown = new SampleWellKnown();
      
      // After the channel is registered, the object needs to be registered
      // with the remoting infrastructure.  So, Marshal is called.
      ObjRef objrefWellKnown = RemotingServices.Marshal(objectWellKnown, "objectWellKnownUri");
      Console.WriteLine("An instance of SampleWellKnown type is published at {0}.", objrefWellKnown.URI);

      Console.WriteLine("Press enter to unregister SampleWellKnown, so that it is no longer available on this channel.");
      Console.ReadLine();
      RemotingServices.Disconnect(objectWellKnown);

      Console.WriteLine("Press enter to end the server process.");
      Console.ReadLine();