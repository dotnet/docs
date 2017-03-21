        // Show the URIs associated with the channel.
        System.Runtime.Remoting.Channels.ChannelDataStore channelData = 
            (System.Runtime.Remoting.Channels.ChannelDataStore) 
            serverChannel.ChannelData;
        foreach (string uri in channelData.ChannelUris)
        {
            Console.WriteLine("The channel URI is {0}.", uri);
        }