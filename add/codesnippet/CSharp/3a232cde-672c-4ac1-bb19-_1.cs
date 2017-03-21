        // Create a client channel.
        System.Collections.Hashtable properties =
            new System.Collections.Hashtable();
        properties["port"] = 9090;
        IClientChannelSinkProvider sinkProvider = null;
        HttpClientChannel clientChannel = new HttpClientChannel(
            properties, sinkProvider);