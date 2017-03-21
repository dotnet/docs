public class ServerSinkProvider : IServerChannelSinkProvider
{

    // The next provider in the chain.
    private IServerChannelSinkProvider nextProvider;

    public IServerChannelSinkProvider Next
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextProvider);
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        set
        {
            nextProvider = value;
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public IServerChannelSink CreateSink (IChannelReceiver channel)
    {

        Console.WriteLine("Creating ServerSink");

        // Create the next sink in the chain.
        IServerChannelSink nextSink = nextProvider.CreateSink(channel);

        // Hook our sink up to it.
        return( new ServerSink(nextSink) );
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void GetChannelData (IChannelDataStore channelData) {}

    // This constructor is required in order to use the provider in file-based configuration.
    // It need not do anything unless you want to use the information in the parameters.
    public ServerSinkProvider (IDictionary properties, ICollection providerData) {}
    
}