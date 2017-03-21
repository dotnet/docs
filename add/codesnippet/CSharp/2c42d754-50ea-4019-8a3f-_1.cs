        // Create a client channel.
        string name = "RemotingClient";
        IClientChannelSinkProvider sinkProvider = null;
        HttpClientChannel clientChannel = new HttpClientChannel(name,
            sinkProvider);