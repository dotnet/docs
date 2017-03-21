        System.Collections.Hashtable properties =
            new System.Collections.Hashtable();
        properties["port"] = 9090;
        IServerChannelSinkProvider sinkProvider = null;
        HttpServerChannel serverChannel = new HttpServerChannel(
            properties, sinkProvider);