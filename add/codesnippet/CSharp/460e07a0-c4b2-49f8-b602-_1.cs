        string name = "RemotingServer";
        int port = 9090;
        IServerChannelSinkProvider sinkProvider = null;
        HttpServerChannel serverChannel = 
            new HttpServerChannel(name, port, sinkProvider);