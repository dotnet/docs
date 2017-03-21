    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public Stream GetRequestStream (IMessage message, ITransportHeaders requestHeaders)
    {
        // Get the request stream from the next sink in the chain.
        return( nextSink.GetRequestStream(message, requestHeaders) );
    }