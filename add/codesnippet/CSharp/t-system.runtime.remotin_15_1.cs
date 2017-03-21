public class ClientSinkProvider : IClientChannelSinkProvider
{

    // The next provider in the chain.
    private IClientChannelSinkProvider nextProvider;

    public IClientChannelSinkProvider Next
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
    public IClientChannelSink CreateSink (IChannelSender channel, String url, Object remoteChannelData)
    {

        Console.WriteLine("Creating ClientSink for {0}", url);

        // Create the next sink in the chain.
        IClientChannelSink nextSink = nextProvider.CreateSink(channel, url, remoteChannelData);

        // Hook our sink up to it.
        return( new ClientSink(nextSink) );
    }

    // This constructor is required in order to use the provider in file-based configuration.
    // It need not do anything unless you want to use the information in the parameters.
    public ClientSinkProvider (IDictionary properties, ICollection providerData) {}
    
}