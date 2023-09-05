using System.ComponentModel;
using System.Collections.Concurrent;
using Azure.Core;

namespace UnitTestingSampleApp.ResourceManager;

public abstract partial class ArmResource
{
    protected ArmResource()
    {}
    
    protected internal ArmResource(ArmClient client, ResourceIdentifier id)
    {
        Client = client;
        Id = id;
    }

    public virtual ResourceIdentifier Id { get; }

    protected internal virtual ArmClient Client { get; }
    
    private readonly ConcurrentDictionary<Type, object> _clientCache = new ConcurrentDictionary<Type, object>();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual T GetCachedClient<T>(Func<ArmClient, T> clientFactory)
        where T : class
    {
        return _clientCache.GetOrAdd(typeof(T), (type) => { return clientFactory(Client); }) as T;
    }
}