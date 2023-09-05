using System.ComponentModel;
using System.Collections.Concurrent;

namespace UnitTestingSampleApp.ResourceManager;

public partial class ArmClient
{
    private readonly ConcurrentDictionary<Type, object> _clientCache = new ConcurrentDictionary<Type, object>();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual T GetCachedClient<T>(Func<ArmClient, T> clientFactory)
            where T : class
    {
        return _clientCache.GetOrAdd(typeof(T), (type) => { return clientFactory(this); }) as T;
    }
}