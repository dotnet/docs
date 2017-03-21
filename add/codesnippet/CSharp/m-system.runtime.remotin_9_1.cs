        // Create and register an IPC channel
        IpcServerChannel serverChannel = new IpcServerChannel("remote");
        ChannelServices.RegisterChannel(serverChannel);