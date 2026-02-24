using Orleans;
using Orleans.Serialization.Activators;

namespace CustomActivators;

// <BasicType>
[GenerateSerializer]
[UseActivator]
public class MyMessage
{
    [Id(0)]
    public string? Text { get; set; }

    public DateTime CreatedAt { get; }

    public MyMessage()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
// </BasicType>

// <BasicActivator>
[RegisterActivator]
public class MyMessageActivator : IActivator<MyMessage>
{
    public MyMessage Create() => new MyMessage();
}
// </BasicActivator>
