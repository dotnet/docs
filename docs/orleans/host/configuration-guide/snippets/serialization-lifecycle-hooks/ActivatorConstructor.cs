using Orleans;
using Orleans.Serialization;

namespace SerializationLifecycleHooks;

// <ActivatorConstructorType>
[GenerateSerializer]
public class CachedLookup
{
    [Id(0)]
    public string Key { get; set; } = string.Empty;

    [Id(1)]
    public string Value { get; set; } = string.Empty;

    [NonSerialized]
    private readonly Serializer<CachedLookup> _serializer;

    [GeneratedActivatorConstructor]
    public CachedLookup(Serializer<CachedLookup> serializer)
    {
        _serializer = serializer;
    }
}
// </ActivatorConstructorType>
