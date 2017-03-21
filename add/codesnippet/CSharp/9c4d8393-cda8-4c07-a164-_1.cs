        // Create the server channel.
        string name = "ipc";
        string portName = "localhost:9090";
        IpcServerChannel serverChannel = 
            new IpcServerChannel(name, portName);