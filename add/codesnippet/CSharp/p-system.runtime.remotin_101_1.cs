    public IClientChannelSink NextChannelSink
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextSink);
        }
    }