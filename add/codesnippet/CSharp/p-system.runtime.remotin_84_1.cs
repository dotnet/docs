        // Get the channel's sink chain.
        IServerChannelSink sinkChain = serverChannel.ChannelSinkChain;
        Console.WriteLine(
            "The type of the server channel's sink chain is {0}.",
            sinkChain.GetType().ToString());