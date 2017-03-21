      IDictionary prop = new Hashtable();
      prop["port"] = 9000;

      IClientChannelSinkProvider clientChain = new BinaryClientFormatterSinkProvider();

      IServerChannelSinkProvider serverChain = new SoapServerFormatterSinkProvider();
      serverChain.Next = new BinaryServerFormatterSinkProvider();

      ChannelServices.RegisterChannel(new HttpChannel(prop, clientChain, serverChain));