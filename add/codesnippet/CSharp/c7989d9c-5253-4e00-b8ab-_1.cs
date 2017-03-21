        // Create the client channel.
        string name = "ipc client";
        System.Runtime.Remoting.Channels.IClientChannelSinkProvider 
            sinkProvider = null;
        IpcClientChannel clientChannel = 
            new IpcClientChannel(name, sinkProvider);