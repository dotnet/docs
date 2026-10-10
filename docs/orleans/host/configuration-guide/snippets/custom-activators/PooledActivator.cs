using Orleans;
using Orleans.Serialization.Activators;
using Microsoft.Extensions.ObjectPool;

namespace CustomActivators;

// <PooledType>
[GenerateSerializer]
[UseActivator]
public class FrequentMessage
{
    [Id(0)]
    public string? Payload { get; set; }

    public void Reset()
    {
        Payload = null;
    }
}
// </PooledType>

// <PooledActivator>
[RegisterActivator]
public class FrequentMessageActivator : IActivator<FrequentMessage>
{
    private readonly ObjectPool<FrequentMessage> _pool;

    public FrequentMessageActivator(ObjectPool<FrequentMessage> pool)
    {
        _pool = pool;
    }

    public FrequentMessage Create() => _pool.Get();
}
// </PooledActivator>
