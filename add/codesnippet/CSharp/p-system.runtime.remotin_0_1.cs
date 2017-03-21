         int myPort = 8085;
         // Creating the 'IDictionary' to set the server object properties.
         IDictionary myDictionary = new Hashtable();
         myDictionary["name"] = "MyServerChannel1";
         myDictionary["priority"] = 2;
         myDictionary["port"] = 8085;
         // Set the properties along with the constructor.
         HttpServerChannel myHttpServerChannel = new HttpServerChannel(myDictionary,
                                             new BinaryServerFormatterSinkProvider());
         // Register the server channel.
         ChannelServices.RegisterChannel(myHttpServerChannel);
         RemotingConfiguration.RegisterWellKnownServiceType(typeof(MyHelloServer), 
                                       "SayHello", WellKnownObjectMode.SingleCall);  
         myHttpServerChannel.WantsToListen = true;
         // Start listening on a specific port.
         myHttpServerChannel.StartListening((object)myPort);
         // Get the name of the channel.
         Console.WriteLine("ChannelName : " + myHttpServerChannel.ChannelName);
         // Get the channel priority.
         Console.WriteLine("ChannelPriority : " + myHttpServerChannel.ChannelPriority);
         // Get the schema of the channel.
         Console.WriteLine("ChannelScheme : " + myHttpServerChannel.ChannelScheme);
         // Get the channel URI.
         Console.WriteLine("GetChannelUri : " + myHttpServerChannel.GetChannelUri());
         // Indicates whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
         Console.WriteLine("WantsToListen : " + myHttpServerChannel.WantsToListen);