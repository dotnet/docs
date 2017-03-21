      IServerChannelSink nextSink = null;
      if (nextProvider != null)
      {
            Console.WriteLine("The next server provider is:"
                                             +nextProvider);
         // Create a sink chain calling the 'SaopServerFormatterProvider'
         // 'CreateSink' method.
         nextSink = nextProvider.CreateSink(channel);
      }
      return new MyServerChannelSink(nextSink);