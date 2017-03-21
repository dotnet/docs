         Dim myPort As Integer = 8085
         ' Creating the 'IDictionary' to set the server object properties.
         Dim myDictionary  As  New Hashtable()
         myDictionary("name") = "MyServerChannel1"
         myDictionary("priority") = 2
         myDictionary("port") = 8085
         ' Set the properties along with the constructor.
         Dim myHttpServerChannel As New HttpServerChannel(myDictionary, _
                 New BinaryServerFormatterSinkProvider())
         ' Register the server channel.
         ChannelServices.RegisterChannel(myHttpServerChannel)
         RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyHelloServer), _
                 "SayHello", WellKnownObjectMode.SingleCall)
         myHttpServerChannel.WantsToListen = true
         ' Start listening on a specific port.
         myHttpServerChannel.StartListening(CType(myPort, Object))
         ' Get the name of the channel.
         Console.WriteLine("ChannelName : " + myHttpServerChannel.ChannelName)
         ' Get the channel priority.
          Console.WriteLine("ChannelPriority : " + myHttpServerChannel.ChannelPriority.ToString())
         ' Get the schema of the channel.
          Console.WriteLine("ChannelScheme : " + myHttpServerChannel.ChannelScheme)
         ' Get the channel URI.
          Console.WriteLine("GetChannelUri : " + myHttpServerChannel.GetChannelUri())
         ' Indicates whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
         Console.WriteLine("WantsToListen : " + myHttpServerChannel.WantsToListen.ToString())