        // Create the client channel.
        System.Collections.IDictionary properties = 
            new System.Collections.Hashtable();
        properties["name"] = "ipc client";
        properties["priority"] = "1";
        System.Runtime.Remoting.Channels.IClientChannelSinkProvider 
            sinkProvider = null;
        IpcClientChannel clientChannel = 
            new IpcClientChannel(properties, sinkProvider);