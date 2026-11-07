using Orleans;
using Orleans.Serialization.Activators;

namespace CustomActivators;

// <GenericType>
[GenerateSerializer]
[UseActivator]
public class Wrapper<T>
{
    [Id(0)]
    public T? Value { get; set; }

    [Id(1)]
    public string? Metadata { get; set; }

    public Wrapper(string metadata)
    {
        Metadata = metadata;
    }
}
// </GenericType>

// <GenericActivator>
[RegisterActivator]
public class WrapperActivator<T> : IActivator<Wrapper<T>>
{
    public Wrapper<T> Create() => new Wrapper<T>("default");
}
// </GenericActivator>
