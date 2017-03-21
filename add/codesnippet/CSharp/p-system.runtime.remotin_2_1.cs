        // Show the URIs associated with the channel.
        ChannelDataStore data = (ChannelDataStore) serverChannel.ChannelData;
        foreach (string uri in data.ChannelUris)
        {
            Console.WriteLine("The channel URI is {0}.", uri);
        }