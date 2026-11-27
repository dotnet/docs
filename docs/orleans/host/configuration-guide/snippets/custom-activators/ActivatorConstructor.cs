using Microsoft.Extensions.Logging;
using Orleans;

namespace CustomActivators;

// <ActivatorConstructorType>
[GenerateSerializer]
public class NotificationMessage
{
    [Id(0)]
    public string Title { get; set; } = string.Empty;

    [Id(1)]
    public string Body { get; set; } = string.Empty;

    [NonSerialized]
    private readonly ILogger<NotificationMessage> _logger;

    [GeneratedActivatorConstructor]
    public NotificationMessage(ILogger<NotificationMessage> logger)
    {
        _logger = logger;
    }

    public void Send()
    {
        _logger.LogInformation("Sending notification: {Title}", Title);
    }
}
// </ActivatorConstructorType>
