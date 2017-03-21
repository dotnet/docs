        // Create the server channel.
        string name = "ipc";
        string portName = "localhost:9090";
        IServerChannelSinkProvider sinkProvider = null;
        IpcServerChannel serverChannel = 
            new IpcServerChannel(name, portName, sinkProvider);