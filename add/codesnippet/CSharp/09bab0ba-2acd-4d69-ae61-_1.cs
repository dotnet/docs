    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public IClientChannelSink CreateSink (IChannelSender channel, String url, Object remoteChannelData)
    {

        Console.WriteLine("Creating ClientSink for {0}", url);

        // Create the next sink in the chain.
        IClientChannelSink nextSink = nextProvider.CreateSink(channel, url, remoteChannelData);

        // Hook our sink up to it.
        return( new ClientSink(nextSink) );
    }